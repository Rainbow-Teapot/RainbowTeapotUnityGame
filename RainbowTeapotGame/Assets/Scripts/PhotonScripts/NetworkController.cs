using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkController : MonoBehaviourPunCallbacks
{ 
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Player has connected to the Photon master server in: " + PhotonNetwork.CloudRegion);
        PhotonNetwork.AutomaticallySyncScene = true;
    }
}
