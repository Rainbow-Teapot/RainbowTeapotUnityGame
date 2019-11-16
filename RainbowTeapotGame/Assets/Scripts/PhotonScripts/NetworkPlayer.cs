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

    private void Awake()
    {
        pv = GetComponent<PhotonView>();
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

    // Update is called once per frame
    void Update()
    {
        if (!pv.IsMine)
        {
            transform.position = Vector3.Lerp(transform.position, positionNet , 0.1f) + Vector3.back * 20.0f * Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, rotationNet, 0.1f);
            
        }
        else
        {
            Debug.Log(GetComponent<Rigidbody>().velocity);
        }
    }


    public void CalloutStartRace()
    {
        pv.RPC("RPC_StartRacing", RpcTarget.AllViaServer);
    }

    
    [PunRPC]
    void RPC_StartRacing()
    {
        GetComponent<CarMovement>().vertSpeed = 20.0f;
    }
    
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        
        // currently there is no strategy to improve on bandwidth, just passing the current distance and speed is enough, 
        // Input could be passed and then used to better control speed value
        //  Data could be wrapped as a vector2 or vector3 to save a couple of bytes
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
           
        }
        else
        {

            positionNet = (Vector3)stream.ReceiveNext();
            rotationNet = (Quaternion)stream.ReceiveNext();
           
        }
        
    }
}
