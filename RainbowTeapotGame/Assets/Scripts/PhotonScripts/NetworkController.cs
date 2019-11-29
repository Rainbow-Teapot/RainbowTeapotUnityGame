using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private int mainMenuSceneIndex;
    [SerializeField]
    private GameObject startButton;

    // Start is called before the first frame update
    void Start()
    {
        //te conectas a la nube de Photon
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Player has connected to the Photon master server in: " + PhotonNetwork.CloudRegion);
        startButton.SetActive(true);
        //si eres el cliente maestro los demás clientes cargaran la misma escena que tu
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneIndex);
    }
}
