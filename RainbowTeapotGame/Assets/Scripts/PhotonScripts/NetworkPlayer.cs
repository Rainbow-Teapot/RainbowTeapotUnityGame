using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkPlayer : MonoBehaviourPun, IPunObservable
{

    private PhotonView pv;

    private Vector3 positionNet;
    private Quaternion rotationNet;

    private Transform transformNet;
    [SerializeField]
    private float lerpSmoothing = 20;

    private Rigidbody rb;



    public Vector3 realPosition = Vector3.zero;
    public Vector3 positionAtLastPacket = Vector3.zero;
    public double currentTime = 0.0;
    public double currentPacketTime = 0.0;
    public double lastPacketTime = 0.0;
    public double timeToReachGoal = 0.0;


    private void Awake()
    {
        pv = GetComponent<PhotonView>();
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (!pv.IsMine)
        {
            MonoBehaviour[] scripts = GetComponents<MonoBehaviour>();

           

            foreach (MonoBehaviour script in scripts)
            {
                if (script is NetworkController) continue;
                if (script is PhotonView) continue;
                if (script is PhotonRigidbodyView) continue;
                if (script is NetworkPlayer) continue;
                if (script is Photon.Pun.UtilityScripts.SmoothSyncMovement) continue;
                script.enabled = false;
            }
        }
    }

    void FixedUpdate()
    {
        if (!pv.IsMine)
        {
            //rb.position = Vector3.Lerp(rb.position, positionNet, Time.fixedDeltaTime * 2.0f);
            //rb.rotation = Quaternion.Lerp(rb.rotation, rotationNet, Time.fixedDeltaTime * 2.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*if (!pv.IsMine)
        {
            transform.position = Vector3.Lerp(transform.position, positionNet , Time.deltaTime) + Vector3.back * 2 * Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, rotationNet, Time.deltaTime);
           
        }*/

        if (!photonView.IsMine)
        {
            timeToReachGoal = currentPacketTime - lastPacketTime;
            currentTime += Time.deltaTime;
            transform.position = Vector3.Lerp(positionAtLastPacket, realPosition + Vector3.back * (float)timeToReachGoal * 10.0f, (float)(currentTime / timeToReachGoal));
        }

    }



    /*public void CalloutStartRace()
    {
        pv.RPC("RPC_StartRacing", RpcTarget.AllViaServer);
    }

    
    [PunRPC]
    void RPC_StartRacing()
    {
        GetComponent<CarMovement>().vertSpeed = 0.0f;
    }*/
    
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        
        // currently there is no strategy to improve on bandwidth, just passing the current distance and speed is enough, 
        // Input could be passed and then used to better control speed value
        //  Data could be wrapped as a vector2 or vector3 to save a couple of bytes
        /*if (stream.IsWriting)
        {
            stream.SendNext(rb.position);
            stream.SendNext(rb.rotation);
           
           
        }
        else
        {

            positionNet = (Vector3)stream.ReceiveNext();
            rotationNet = (Quaternion)stream.ReceiveNext();
            

            float lag = Mathf.Abs((float)(PhotonNetwork.Time - info.SentServerTime));
            positionNet += (new Vector3(0,0,-5.0f) * 10 * lag);

            
        }*/

        if (stream.IsWriting)
        {
            stream.SendNext((Vector3)transform.position);
        }
        else
        {
            currentTime = 0.0;
            positionAtLastPacket = transform.position;
            realPosition = (Vector3)stream.ReceiveNext();
            lastPacketTime = currentPacketTime;
            currentPacketTime = info.SentServerTime;
        }

    }
}
