using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LobyManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject multiplayerButton;
    [SerializeField]
    private int roomMenuSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log("El jugador se ha metido al lobby");
        multiplayerButton.SetActive(true);
    }

    public void GoRoomMenu()
    {
        Debug.Log("Le he dado al boton para ir al menu de room");
        SceneManager.LoadScene(roomMenuSceneIndex);
    }
    
}
