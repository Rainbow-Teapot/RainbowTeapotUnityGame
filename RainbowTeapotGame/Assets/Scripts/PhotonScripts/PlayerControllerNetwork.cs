// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlayerControl.cs" company="Exit Games GmbH">
//   Part of: Photon Unity Networking Demos
// </copyright>
// <summary>
//  Used in SlotRacer Demo
// </summary>
// <author>developer@exitgames.com</author>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine;

using System.Collections;

using Photon.Pun.Demo.SlotRacer.Utils;
using Photon.Pun.UtilityScripts;
using Photon.Pun;
using Photon.Pun.Demo.SlotRacer;

/// <summary>
/// Player control. 
/// Interface the User Inputs and PUN
/// Handle the Car instance 
/// </summary>
[RequireComponent(typeof(SplineWalker))]
    public class PlayerControllerNetwork : MonoBehaviourPun, IPunObservable
    {

        public GameObject CarPrefab;
        public float MaximumSpeed = 20;
        public float Drag = 5;

        public bool startRacing = false;

        /// Only used for locaPlayer
        public float CurrentSpeed = 0;
        /// Only used for locaPlayer
        private float CurrentDistance;

        private GameObject CarInstance;
        private SplineWalker SplineWalker;


        /// <summary>
        /// flag to force latest data to avoid initial drifts when player is instantiated.
        /// </summary>
        private bool m_firstTake = true;


        private float m_input;


        #region IPunObservable implementation

        /// <summary>
        /// this is where data is sent and received for this Component from the PUN Network.
        /// </summary>
        /// <param name="stream">Stream.</param>
        /// <param name="info">Info.</param>
        void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            // currently there is no strategy to improve on bandwidth, just passing the current distance and speed is enough, 
            // Input could be passed and then used to better control speed value
            //  Data could be wrapped as a vector2 or vector3 to save a couple of bytes
            if (stream.IsWriting)
            {
                //mandar además la posición en X y la velocidad en X
                stream.SendNext(this.CurrentDistance);
                stream.SendNext(this.CurrentSpeed);
                stream.SendNext(this.m_input);
            }
            else
            {
                if (this.m_firstTake)
                {
                    this.m_firstTake = false;
                }

                this.CurrentDistance = (float)stream.ReceiveNext();
                this.CurrentSpeed = (float)stream.ReceiveNext() + 1f;
                this.m_input = (float)stream.ReceiveNext();
            }
        }

        #endregion IPunObservable implementation


        #region private

        /// <summary>
        /// Setups the car on track.
        /// </summary>
        /// <param name="gridStartIndex">Grid start index.</param>
        private void SetupCarOnTrack(int gridStartIndex)
        {
            // Setup the SplineWalker to be on the right starting grid position.
            this.SplineWalker.spline = SlotLanes.Instance.GridPositions[gridStartIndex].Spline;
            this.SplineWalker.currentDistance = SlotLanes.Instance.GridPositions[gridStartIndex].currentDistance;
            this.SplineWalker.ExecutePositioning();

            // create a new car
            //this.CarInstance = (GameObject)Instantiate(this.CarPrefab, this.transform.position, this.transform.rotation);
            this.CarInstance = this.CarPrefab;

            // We'll wait for the first serializatin to pass, else we'll have a glitch where the car is positioned at the wrong position.
            if (!this.photonView.IsMine)
            {
                this.CarInstance.SetActive(false);
            }

            // depending on wether we control this instance locally, we force the car to become active ( because when you are alone in the room, serialization doesn't happen, but still we want to allow the user to race around)
            if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
            {
                this.m_firstTake = false;
            }

            //this.CarInstance.transform.SetParent(this.transform);
        }

        #endregion private


        #region Monobehaviour

        /// <summary>
        /// Cache the SplineWalker and flag context for clean serialization when joining late.
        /// </summary>
        private void Awake()
        {
            this.SplineWalker = this.GetComponent<SplineWalker>();
            this.m_firstTake = true;
        }

        /// <summary>
        /// Start this instance as a coroutine
        /// Waits for a Playernumber to be assigned and only then setup the car and put it on the right starting position on the lane.
        /// </summary>
        private IEnumerator Start()
        {
            // Wait until a Player Number is assigned
            // PlayerNumbering component must be in the scene.
            yield return new WaitUntil(() => this.photonView.Owner.GetPlayerNumber() >= 0);
        //transform.position += Vector3.back * 0.25f;
        
            // now we can set it up.
            this.SetupCarOnTrack(this.photonView.Owner.GetPlayerNumber());
        if (photonView.IsMine)
        {
            GetComponent<CarMovement>().enabled = true;
        }
        
    }



        /// <summary>
        /// Make sure we delete instances linked to this component, else when user is leaving the room, its car instance would remain 
        /// </summary>
        private void OnDestroy()
        {
            Destroy(this.CarInstance);
        }

        // Update is called once per frame
        private void Update()
        {
            if (this.SplineWalker == null || this.CarInstance == null)
            {
                return;
            }

            if (this.photonView.IsMine)
            {
           
                //simplemente se le pasa la currentSpeed, que es la componente z de la velocidad.
                //la POSICIÓN EN Z la pone la CURVA DE BEZIER
                this.SplineWalker.Speed = this.CurrentSpeed;
                this.CurrentDistance = this.SplineWalker.currentDistance;
            }
            else //EL COCHE SIMULADO
            {

                //para la posición en la Z               
                this.SplineWalker.Speed = this.CurrentSpeed;
                if (this.CurrentDistance != 0 && this.SplineWalker.currentDistance != this.CurrentDistance)
                {
                    //Debug.Log ("SplineWalker.currentDistance=" + SplineWalker.currentDistance + " CurrentDistance=" + CurrentDistance);
                    this.SplineWalker.Speed += (this.CurrentDistance - this.SplineWalker.currentDistance) * Time.deltaTime * 50f;
                }

                //para la posición en la X

            }

            // Only activate the car if we are sure we have the proper positioning, else it will glitch visually during the initialisation process.
            if (!this.m_firstTake && !this.CarInstance.activeSelf)
            {
                this.CarInstance.SetActive(true);
                this.SplineWalker.Speed = this.CurrentSpeed;
                this.SplineWalker.SetPositionOnSpline(this.CurrentDistance);

            }
        }

        #endregion Monobehaviour

        public void CalloutStartRace()
        {
            this.photonView.RPC("RPC_StartRacing", RpcTarget.AllViaServer);
        }


        [PunRPC]
        void RPC_StartRacing()
        {
            this.startRacing = true;
        }
}

