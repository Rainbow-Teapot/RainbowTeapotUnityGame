using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private int roomSize = 6;
    [SerializeField]
    private int waitingRoomSceneIndex;

    [SerializeField]
    private GameObject randomRoomJoinButton;
    [SerializeField]
    private GameObject cancelRandomRoomJoinButton;

    [SerializeField]
    private InputField createRoomInput;
    [SerializeField]
    private InputField joinCustomRoomInput;

    private void Start()
    {
        if (!PhotonNetwork.InLobby)
        {
            Debug.Log("El jugador no está en ningun lobby");
            PhotonNetwork.JoinLobby();
        }

       
    }

    public void JoinRandomRoom()
    {
        randomRoomJoinButton.SetActive(false);
        cancelRandomRoomJoinButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
    }

    public void JoinOwnRoom()
    {
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)roomSize };
        PhotonNetwork.JoinOrCreateRoom(createRoomInput.text,roomOps,PhotonNetwork.CurrentLobby);
        Debug.Log(createRoomInput.text);
    }

    public void JoinCustomRoomByName()
    {
        PhotonNetwork.JoinRoom(joinCustomRoomInput.text);
    }

    public override void OnJoinedRoom() //Callback function for when we successfully create or join a room.
    {
        // called when our player joins the room
        // load into waiting room scene
        PhotonNetwork.LeaveLobby();
        SceneManager.LoadScene(waitingRoomSceneIndex);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        CreateRoom();
    }

    private void CreateRoom()
    {
        Debug.Log("Creating room now");
        int randomRoomNumber = Random.Range(0, 10000);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)roomSize };
        PhotonNetwork.CreateRoom("Room" + randomRoomNumber, roomOps);
        Debug.Log(randomRoomNumber);
    }



    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to create room... trying again");
        CreateRoom();
    }

    public override void OnEnable()
    {
        //register to photon callback functions
        PhotonNetwork.AddCallbackTarget(this);
    }
    public override void OnDisable()
    {
        //unregister to photon callback functions
        PhotonNetwork.RemoveCallbackTarget(this);
    }
    
}
