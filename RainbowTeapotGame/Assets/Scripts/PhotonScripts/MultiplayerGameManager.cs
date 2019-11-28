// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AsteroidsGameManager.cs" company="Exit Games GmbH">
//   Part of: Asteroid demo
// </copyright>
// <summary>
//  Game Manager for the Asteroid Demo
// </summary>
// <author>developer@exitgames.com</author>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections;

using UnityEngine;
using UnityEngine.UI;

using Photon.Realtime;
using Photon.Pun.UtilityScripts;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using System.IO;
using UnityEngine.SceneManagement;

namespace Photon.Pun.Demo.Asteroids
{
    public class MultiplayerGameManager : MonoBehaviourPunCallbacks
    {
        public static MultiplayerGameManager Instance = null;

        [SerializeField]
        private Camera mainCamera;
        private GameObject player;

        public bool isDebug = true;
        public vehicles vehiclePicked;

        private PhotonView pv;

        [SerializeField]
        private Transform startPosition;

        #region UNITY

        public void Awake()
        {
            Instance = this;
            pv = GetComponent<PhotonView>();
        }

        public override void OnEnable()
        {
            base.OnEnable();

            CountdownTimer.OnCountdownTimerHasExpired += OnCountdownTimerIsExpired;
        }

        public void Start()
        {
            //InfoText.text = "Waiting for other players...";

            StartGame();

            Hashtable props = new Hashtable
            {
                {GameStateInfo.PLAYER_LOADED_LEVEL, true}
            };
            PhotonNetwork.LocalPlayer.SetCustomProperties(props);
        }

        public override void OnDisable()
        {
            base.OnDisable();

            CountdownTimer.OnCountdownTimerHasExpired -= OnCountdownTimerIsExpired;
        }

        #endregion

        #region COROUTINES

        private IEnumerator EndOfGame(string winner, int score)
        {
            float timer = 5.0f;

            while (timer > 0.0f)
            {
                //InfoText.text = string.Format("Player {0} won with {1} points.\n\n\nReturning to login screen in {2} seconds.", winner, score, timer.ToString("n2"));

                yield return new WaitForEndOfFrame();

                timer -= Time.deltaTime;
            }

            PhotonNetwork.LeaveRoom();
        }

        public void EndOfRace()
        {
            PhotonNetwork.LeaveRoom();
            
            
        }

        #endregion

        #region PUN CALLBACKS

        public override void OnDisconnected(DisconnectCause cause)
        {
            /*if (pv.IsMine)
            //{
                UnityEngine.SceneManagement.SceneManager.LoadScene("Lobby");
            //}*/
        }

        public override void OnLeftRoom()
        {
            
                SceneManager.LoadScene("GameOver");
            
            //PhotonNetwork.Disconnect();
        }

        public override void OnMasterClientSwitched(Player newMasterClient)
        {
            if (PhotonNetwork.LocalPlayer.ActorNumber == newMasterClient.ActorNumber)
            {
                
            }
        }

        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            CheckEndOfGame();
        }

        public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
        {
            if (changedProps.ContainsKey(AsteroidsGame.PLAYER_LIVES))
            {
                CheckEndOfGame();
                return;
            }

            if (!PhotonNetwork.IsMasterClient)
            {
                return;
            }

            if (changedProps.ContainsKey(GameStateInfo.PLAYER_LOADED_LEVEL))
            {
                if (CheckAllPlayerLoadedLevel())
                {
                    Hashtable props = new Hashtable
                    {
                        {CountdownTimer.CountdownStartTime, (float) PhotonNetwork.Time}
                    };
                    PhotonNetwork.CurrentRoom.SetCustomProperties(props);
                }
            }
        }

        #endregion

        private void StartGame()
        {
            int playerNumber = PhotonNetwork.LocalPlayer.GetPlayerNumber();

            Vector3 position = new Vector3((playerNumber * 3 - 3), startPosition.position.y, startPosition.position.z);

            //Vector3 position = new Vector3(playerNumber * 3 - 3, 0.5f, 0.0f);

            string vehicleName = "CarNetwork";

            if (isDebug)
            {
                vehicleName = ChooseVehicle();
            }

            player = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", vehicleName), position, Quaternion.identity, 0);

            //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"), position, Quaternion.identity, 0);

            player.GetComponent<InputedMovement>().SetCarCamera(mainCamera);
            //player.GetComponent<CarMovement>().horSpeed = 0.0f;
            mainCamera.GetComponent<CameraController>().setTarget(player);
        }

        private bool CheckAllPlayerLoadedLevel()
        {
            foreach (Player p in PhotonNetwork.PlayerList)
            {
                object playerLoadedLevel;

                if (p.CustomProperties.TryGetValue(AsteroidsGame.PLAYER_LOADED_LEVEL, out playerLoadedLevel))
                {
                    if ((bool) playerLoadedLevel)
                    {
                        continue;
                    }
                }

                return false;
            }

            return true;
        }

        public void CheckEndOfGame()
        {
            bool allDestroyed = true;

            foreach (Player p in PhotonNetwork.PlayerList)
            {
                object lives;
                if (p.CustomProperties.TryGetValue(AsteroidsGame.PLAYER_LIVES, out lives))
                {
                    if ((int) lives > 0)
                    {
                        allDestroyed = false;
                        break;
                    }
                }
            }

            if (allDestroyed)
            {
                if (PhotonNetwork.IsMasterClient)
                {
                    StopAllCoroutines();
                }

                string winner = "";
                int score = -1;

                foreach (Player p in PhotonNetwork.PlayerList)
                {
                    if (p.GetScore() > score)
                    {
                        winner = p.NickName;
                        score = p.GetScore();
                    }
                }

                StartCoroutine(EndOfGame(winner, score));
            }
        }

        private void OnCountdownTimerIsExpired()
        {
            StartRace();
        }

        private void StartRace()
        {
            Debug.Log("Empieza la carrera");
            player.GetComponent<PlayerControllerNetwork>().CalloutStartRace();
            
            //player.GetComponent<CarMovement>().vertSpeed = 20;
        }

        private string ChooseVehicle()
        {
            PlayerInfo vehicleChosen = GameObject.Find("PlayerInfo").GetComponent<PlayerInfo>();
            return vehicleChosen.vehiclePicked.ToString() + "Network";
        }
    }
}