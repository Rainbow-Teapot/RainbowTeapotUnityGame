using ExitGames.Client.Photon;
using Photon.Realtime;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Photon.Pun.UtilityScripts;

namespace Photon.Pun.Demo.Asteroids
{
    public class LobbyMainPanel : MonoBehaviourPunCallbacks
    {

        LanguageManager lang = new LanguageManager();
        Animator animLogin;
       

        [Header("Login Panel")]
        public GameObject LoginPanel;
        public TextMeshProUGUI breakToWinText;
        public TextMeshProUGUI nameText;
        public TextMeshProUGUI enterPlayer;
        public TextMeshProUGUI loginText;       
        public InputField PlayerNameInput;

        [Header("Selection Panel")]
        public GameObject SelectionPanel;
        public TextMeshProUGUI trainingText;
        public TextMeshProUGUI multiplayerText;
        public TextMeshProUGUI breakToWinText2;

        [Header("Configuration Panel")]
        public GameObject ConfigurationPanel;
        public TextMeshProUGUI configText;
        public TextMeshProUGUI musicText;
        public TextMeshProUGUI soundText;
        public TextMeshProUGUI languageText;
        public Button buttonFlag;
        public Sprite EngFlag;
        public Sprite SpaFlag;
        public Button buttonSound;
        public Button buttonMusic;
        public Sprite tick;
        public Sprite tickOK; 

        [Header("Credits Panel")]
        public GameObject CreditsPanel;
        public TextMeshProUGUI creditsText;

        [Header("Create Room Panel")]
        public GameObject CreateRoomPanel;

        public InputField RoomNameInputField;
        public InputField MaxPlayersInputField;

        [Header("Character Selection Panel")]
        public GameObject CharacterSelectionPanel;
        public GameObject CharacterSelector;
        public GameObject CharacterShowcasePanel;
        public CharacterShowcase CharacterShowcase;
        public TextMeshProUGUI chooseRiderText;
        public TextMeshProUGUI startText;
        

        [Header("Join Random Room Panel")]
        public GameObject JoinRandomRoomPanel;
        public TextMeshProUGUI tryingToJoinText;
        private readonly int MAX_PLAYERS_PER_ROOM = 5;

        [Header("Room List Panel")]
        public GameObject RoomListPanel;
        public GameObject RoomListContent;
        public GameObject RoomListEntryPrefab;

        [Header("Inside Room Panel")]
        public GameObject InsideRoomPanel;
        public TextMeshProUGUI leaveGameText;
        public TextMeshProUGUI startGameText;
        public TextMeshProUGUI startGameText2;
        public TextMeshProUGUI readyText;
        public TextMeshProUGUI messageReadyText;
        public TextMeshProUGUI messageStartGameText;

        [Header("End Game Panel")]
        public GameObject EndGamePanel;

        [Header("Player Info")]
        public PlayerInfo playerInfo;

        public Button StartGameButton;        
        public GameObject PlayerListEntryPrefab;

        private Dictionary<string, RoomInfo> cachedRoomList;
        private Dictionary<string, GameObject> roomListEntries;
        private Dictionary<int, GameObject> playerListEntries;
        private string playerName;

        #region UNITY

        public void Awake()
        {
            PhotonNetwork.AutomaticallySyncScene = true;

            cachedRoomList = new Dictionary<string, RoomInfo>();
            roomListEntries = new Dictionary<string, GameObject>();

            animLogin = LoginPanel.GetComponent<Animator>();          


        }

        private void Start()
        {

            PlayerNameInput.text = GetComponent<RandomNameGenerator>().GetRandomPlayerName();

            playerInfo = GameObject.Find("PlayerInfo").GetComponent<PlayerInfo>();
                

            if (playerInfo.hasBeenLogged)
            {

                
                SetActivePanel(SelectionPanel.name);
            }

            Debug.Log(playerInfo.lang);

            updateTexts();
        }

        private void Update()
        {   
        }

        #endregion

        #region PUN CALLBACKS

        public override void OnConnectedToMaster()
        {
            //this.SetActivePanel(SelectionPanel.name);
            
            //this.SetActivePanel(CharacterSelectionPanel.name);
        }

        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            ClearRoomListView();

            UpdateCachedRoomList(roomList);
            UpdateRoomListView();
        }

        public override void OnLeftLobby()
        {
            cachedRoomList.Clear();

            ClearRoomListView();
        }

        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            SetActivePanel(SelectionPanel.name);
        }

        public override void OnJoinRoomFailed(short returnCode, string message)
        {
            SetActivePanel(SelectionPanel.name);
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            string roomName = "Room " + Random.Range(1000, 10000);

            RoomOptions options = new RoomOptions {MaxPlayers = (byte)MAX_PLAYERS_PER_ROOM};

            PhotonNetwork.CreateRoom(roomName, options, null);
        }

        public override void OnJoinedRoom()
        {
            SetActivePanel(InsideRoomPanel.name);

            if (playerListEntries == null)
            {
                playerListEntries = new Dictionary<int, GameObject>();
            }

            foreach (Player p in PhotonNetwork.PlayerList)
            {
                GameObject entry = Instantiate(PlayerListEntryPrefab);
                entry.transform.SetParent(InsideRoomPanel.transform);
                entry.transform.localScale = new Vector3(1.0f,1.0f,1.0f);
                entry.GetComponent<PlayerListEntry>().Initialize(p.ActorNumber, p.NickName);

                object isPlayerReady;
                if (p.CustomProperties.TryGetValue(GameStateInfo.PLAYER_READY, out isPlayerReady))
                {
                    entry.GetComponent<PlayerListEntry>().SetPlayerReady((bool) isPlayerReady);
                }

                playerListEntries.Add(p.ActorNumber, entry);
            }
            messageStartGameText.gameObject.SetActive(CheckPlayersReady());
            StartGameButton.gameObject.SetActive(CheckPlayersReady());

            Hashtable props = new Hashtable
            {
                {GameStateInfo.PLAYER_LOADED_LEVEL, false}
            };
            PhotonNetwork.LocalPlayer.SetCustomProperties(props);
        }

        public override void OnLeftRoom()
        {
            SetActivePanel(SelectionPanel.name);

            foreach (GameObject entry in playerListEntries.Values)
            {
                Destroy(entry.gameObject);
            }

            playerListEntries.Clear();
            playerListEntries = null;
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            GameObject entry = Instantiate(PlayerListEntryPrefab);
            
            entry.transform.SetParent(InsideRoomPanel.transform);
            entry.transform.localScale = Vector3.one;
            entry.GetComponent<PlayerListEntry>().Initialize(newPlayer.ActorNumber, newPlayer.NickName);
            object playerVehicle;
            if (newPlayer.CustomProperties.TryGetValue(GameStateInfo.VEHICLE, out playerVehicle))
                entry.GetComponent<PlayerListEntry>().SetPlayerVehicleSprite((int)playerVehicle);
            playerListEntries.Add(newPlayer.ActorNumber, entry);

            if (PhotonNetwork.CurrentRoom.PlayerCount == MAX_PLAYERS_PER_ROOM)
            {
                PhotonNetwork.CurrentRoom.IsOpen = false;
                PhotonNetwork.CurrentRoom.IsVisible = false;
            }
            messageStartGameText.gameObject.SetActive(CheckPlayersReady());
            StartGameButton.gameObject.SetActive(CheckPlayersReady());
        }

        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            Destroy(playerListEntries[otherPlayer.ActorNumber].gameObject);
            playerListEntries.Remove(otherPlayer.ActorNumber);

            PhotonNetwork.CurrentRoom.IsOpen = true;
            PhotonNetwork.CurrentRoom.IsVisible = true;
            messageStartGameText.gameObject.SetActive(CheckPlayersReady());
            StartGameButton.gameObject.SetActive(CheckPlayersReady());
        }

        public override void OnMasterClientSwitched(Player newMasterClient)
        {
            if (PhotonNetwork.LocalPlayer.ActorNumber == newMasterClient.ActorNumber)
            {
                messageStartGameText.gameObject.SetActive(CheckPlayersReady());
                StartGameButton.gameObject.SetActive(CheckPlayersReady());
            }
        }

        public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
        {
            if (playerListEntries == null)
            {
                playerListEntries = new Dictionary<int, GameObject>();
            }

            GameObject entry;
            if (playerListEntries.TryGetValue(targetPlayer.ActorNumber, out entry))
            {
                object isPlayerReady;
                if (changedProps.TryGetValue(GameStateInfo.PLAYER_READY, out isPlayerReady))
                {
                    entry.GetComponent<PlayerListEntry>().SetPlayerReady((bool) isPlayerReady);
                }
            }
            messageStartGameText.gameObject.SetActive(CheckPlayersReady());
            StartGameButton.gameObject.SetActive(CheckPlayersReady());
        }

        #endregion

        #region UI CALLBACKS

        public void OnBackButtonClicked()
        {
            if (PhotonNetwork.InLobby)
            {
                PhotonNetwork.LeaveLobby();
            }

            SetActivePanel(SelectionPanel.name);
        }
         
        public void OnCreateRoomButtonClicked()
        {
            string roomName = RoomNameInputField.text;
            roomName = (roomName.Equals(string.Empty)) ? "Room " + Random.Range(1000, 10000) : roomName;

            byte maxPlayers;
            byte.TryParse(MaxPlayersInputField.text, out maxPlayers);
            maxPlayers = (byte) Mathf.Clamp(maxPlayers, 2, MAX_PLAYERS_PER_ROOM);

            RoomOptions options = new RoomOptions {MaxPlayers = maxPlayers};

            PhotonNetwork.CreateRoom(roomName, options, null);
        }

        public void OnTrainingButtonClicked()
        {
            playerInfo.online = false;
            
            SetActivePanel(CharacterSelectionPanel.name);
        }

        public void OnJoinRandomRoomButtonClicked()
        {
            if (!PhotonNetwork.IsConnected)
                PhotonNetwork.ConnectUsingSettings();

            playerInfo.online = true;
            SetActivePanel(CharacterSelectionPanel.name);
        }
        public void OnCharacterClicked(Button button) {
            Debug.Log(button.name);
            VehicleButton vehicleClicked = button.GetComponent<VehicleButton>();
            
            playerInfo.vehiclePicked = vehicleClicked.vehicle;

            FindObjectOfType<AudioManager>().Character(playerInfo.vehiclePicked.ToString());
        
        
        //iniciar animación y después de un segundo mostrar el coche

        CharacterShowcase.SetCarPicked(vehicleClicked.vehicle);
            StartCoroutine("ShowShowcaseCoroutine");
            
        }

        public void OnMusicButtonClicked(Button button) {
            FindObjectOfType<AudioManager>().Play("Check");
            FindObjectOfType<PlayerInfo>().musicOn = (!FindObjectOfType<PlayerInfo>().musicOn);            
            button.image.overrideSprite = FindObjectOfType<PlayerInfo>().musicOn ? tickOK : tick;
            FindObjectOfType<MusicManager>().PlayOrPause("MenuTheme");
        }

        public void OnSoundButtonClicked(Button button) {
            FindObjectOfType<AudioManager>().Play("Check");
            FindObjectOfType<PlayerInfo>().soundsOn = (!FindObjectOfType<PlayerInfo>().soundsOn);
            button.image.overrideSprite = FindObjectOfType<PlayerInfo>().soundsOn ? tickOK : tick;
        }

        public void OnChangeLanguageClicked()
        {
            if (playerInfo.lang == 0) //ENG --> SPA
            {
                playerInfo.lang = 1;               
            }
            else { //SPA --> ENG
                playerInfo.lang = 0;
                
            }
            updateTexts();

        }


        private System.Collections.IEnumerator ShowShowcaseCoroutine()
        {
            yield return new WaitForSeconds(0.35f);
            CharacterSelectionPanel.SetActive(false);
            CharacterShowcasePanel.SetActive(true);
        }

        public void OnBackCharacterShowcaseClicked()
        {
            CharacterSelectionPanel.SetActive(true);
            CharacterShowcasePanel.SetActive(false);
        }

        public void OnConfigurationButtonClicked() {            
            SetActivePanel(ConfigurationPanel.name);
        }

        public void OnCreditsButtonClicked() {            
            SetActivePanel(CreditsPanel.name);
        }

        /// <summary>
        /// /////////////////////////////////
        /// </summary>
        public void OnJoinButtonClicked()
        {
            if (playerInfo.online)
            {
                SetActivePanel(JoinRandomRoomPanel.name);
                Hashtable props = new Hashtable() { { GameStateInfo.VEHICLE, playerInfo.vehiclePicked } };
                PhotonNetwork.LocalPlayer.SetCustomProperties(props);
                
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                float random = Random.Range(0, 15.0f);

                if (random < 5)
                {
                    playerInfo.level = levels.SNOWY_MOUNTAIN;
                    PhotonNetwork.LoadLevel("Level1Offline");
                }
                else if (random < 10)
                {
                    playerInfo.level = levels.CANDY;
                    PhotonNetwork.LoadLevel("Level2Offline");
                }
                else
                {
                    playerInfo.level = levels.NIGHTMARES;
                    PhotonNetwork.LoadLevel("Level3Offline");

                }
            }
        }
        /// <summary>
        /// ////////////////////////
        /// </summary>
        
        public void OnLeaveGameButtonClicked()
        {
            PhotonNetwork.LeaveRoom();
        }

        public void OnLoginButtonClicked()
        {
            
            playerName = PlayerNameInput.text;
            playerInfo.hasBeenLogged = true;
            if (!playerName.Equals(""))
            {
                animLogin.SetBool("NextScreen", true);
                PhotonNetwork.LocalPlayer.NickName = playerName;
                this.SetActivePanel(SelectionPanel.name);


            }
            else
            {
                animLogin.SetBool("NextScreen", false);
                Debug.LogError("Player Name is invalid.");
            }
        }

        public void OnRoomListButtonClicked()
        {
            if (!PhotonNetwork.InLobby)
            {
                PhotonNetwork.JoinLobby();
            }

            SetActivePanel(RoomListPanel.name);
        }

        public void OnStartGameButtonClicked()
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false;


            float random = Random.Range(0, 15.0f);

            if (random < 5)
            {
                playerInfo.level = levels.SNOWY_MOUNTAIN;
                PhotonNetwork.LoadLevel("Level1Online");
            }
            else if (random < 10)
            {
                playerInfo.level = levels.CANDY;
                PhotonNetwork.LoadLevel("Level2Online");
            }
            else {
                playerInfo.level = levels.NIGHTMARES;
                PhotonNetwork.LoadLevel("Level3Online");

            }

        }

        #endregion

        private bool CheckPlayersReady()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                return false;
            }

            foreach (Player p in PhotonNetwork.PlayerList)
            {
                object isPlayerReady;
                if (p.CustomProperties.TryGetValue(GameStateInfo.PLAYER_READY, out isPlayerReady))
                {
                    if (!(bool) isPlayerReady)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
        
        private void ClearRoomListView()
        {
            foreach (GameObject entry in roomListEntries.Values)
            {
                Destroy(entry.gameObject);
            }

            roomListEntries.Clear();
        }

        public void LocalPlayerPropertiesUpdated()
        {
            messageStartGameText.gameObject.SetActive(CheckPlayersReady());
            StartGameButton.gameObject.SetActive(CheckPlayersReady());
        }

        private void SetActivePanel(string activePanel)
        {
            LoginPanel.SetActive(activePanel.Equals(LoginPanel.name));
            SelectionPanel.SetActive(activePanel.Equals(SelectionPanel.name));
            CreateRoomPanel.SetActive(activePanel.Equals(CreateRoomPanel.name));
            JoinRandomRoomPanel.SetActive(activePanel.Equals(JoinRandomRoomPanel.name));
            RoomListPanel.SetActive(activePanel.Equals(RoomListPanel.name));    // UI should call OnRoomListButtonClicked() to activate this
            InsideRoomPanel.SetActive(activePanel.Equals(InsideRoomPanel.name));
            CharacterSelectionPanel.SetActive(activePanel.Equals(CharacterSelectionPanel.name));
            CharacterShowcasePanel.SetActive(activePanel.Equals(CharacterShowcasePanel.name));
            ConfigurationPanel.SetActive(activePanel.Equals(ConfigurationPanel.name));
            CreditsPanel.SetActive(activePanel.Equals(CreditsPanel.name));
            EndGamePanel.SetActive(activePanel.Equals(EndGamePanel.name));
        }

        private void UpdateCachedRoomList(List<RoomInfo> roomList)
        {
            foreach (RoomInfo info in roomList)
            {
                // Remove room from cached room list if it got closed, became invisible or was marked as removed
                if (!info.IsOpen || !info.IsVisible || info.RemovedFromList)
                {
                    if (cachedRoomList.ContainsKey(info.Name))
                    {
                        cachedRoomList.Remove(info.Name);
                    }

                    continue;
                }

                // Update cached room info
                if (cachedRoomList.ContainsKey(info.Name))
                {
                    cachedRoomList[info.Name] = info;
                }
                // Add new room info to cache
                else
                {
                    cachedRoomList.Add(info.Name, info);
                }
            }
        }

        private void UpdateRoomListView()
        {
            foreach (RoomInfo info in cachedRoomList.Values)
            {
                GameObject entry = Instantiate(RoomListEntryPrefab);
                entry.transform.SetParent(RoomListContent.transform);
                entry.transform.localScale = Vector3.one;
                entry.GetComponent<RoomListEntry>().Initialize(info.Name, (byte)info.PlayerCount, info.MaxPlayers);

                roomListEntries.Add(info.Name, entry);
            }
        }


        public void updateTexts() {

            nameText.text = lang.getText(playerInfo.lang, 0);
            //PlayerNameInput.text = lang.getText(playerInfo.lang, 17) + " " + Random.Range(1000, 10000);
            enterPlayer.text = lang.getText(playerInfo.lang, 1);
            loginText.text = lang.getText(playerInfo.lang, 2);
            trainingText.text = lang.getText(playerInfo.lang, 3);
            multiplayerText.text = lang.getText(playerInfo.lang, 4);
            creditsText.text = lang.getText(playerInfo.lang, 5);
            configText.text = lang.getText(playerInfo.lang, 6);
            musicText.text = lang.getText(playerInfo.lang, 7);
            soundText.text = lang.getText(playerInfo.lang, 8);
            languageText.text = lang.getText(playerInfo.lang, 9);
            chooseRiderText.text = lang.getText(playerInfo.lang, 10);
            startText.text = lang.getText(playerInfo.lang, 11);
            tryingToJoinText.text = lang.getText(playerInfo.lang, 12);
            leaveGameText.text = lang.getText(playerInfo.lang, 13);
            startGameText.text = lang.getText(playerInfo.lang, 14);
            startGameText2.text = lang.getText(playerInfo.lang, 14);
            readyText.text = lang.getText(playerInfo.lang, 15);
            messageReadyText.text = lang.getText(playerInfo.lang, 19);
            messageStartGameText.text = lang.getText(playerInfo.lang, 20);
            breakToWinText.text = lang.getText(playerInfo.lang, 24);
            breakToWinText2.text = lang.getText(playerInfo.lang, 24);


            if (playerInfo.lang == 0)
            {
                buttonFlag.image.overrideSprite = SpaFlag;
            }
            else {
                buttonFlag.image.overrideSprite = EngFlag;
            }

            buttonSound.image.overrideSprite = playerInfo.soundsOn ? tickOK : tick;
            buttonMusic.image.overrideSprite = playerInfo.musicOn ? tickOK : tick;

        }
    }
}