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
        private Transform[] startingPositions;

        [SerializeField]
        private ControllerGUI controller;

        private float[] playerDistances;

        #region UNITY

        public void Awake()
        {
            Instance = this;
            pv = GetComponent<PhotonView>();
        }

        public override void OnEnable()
        {
            base.OnEnable();
            PhotonNetwork.AutomaticallySyncScene = false;
            CountdownTimer.OnCountdownTimerHasExpired += OnCountdownTimerIsExpired;
        }

        public void Start()
        {
            //InfoText.text = "Waiting for other players...";
            playerDistances = new float[PhotonNetwork.PlayerList.Length];

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

        /*private IEnumerator EndOfGame(string winner, int score)
        {
            float timer = 5.0f;

            while (timer > 0.0f)
            {
                //InfoText.text = string.Format("Player {0} won with {1} points.\n\n\nReturning to login screen in {2} seconds.", winner, score, timer.ToString("n2"));

                yield return new WaitForEndOfFrame();

                timer -= Time.deltaTime;
            }

            PhotonNetwork.LeaveRoom();
        }*/

        public void EndOfRace()
        {
            //if(playerNumber == PhotonNetwork.LocalPlayer.GetPlayerNumber() && pv.IsOwnerActive && pv.IsMine)
            player.GetComponent<PlayerControllerNetwork>().LeaveRoom();
        }

        #endregion

        #region PUN CALLBACKS

        public override void OnDisconnected(DisconnectCause cause)
        {
            /*if (pv.IsMine)
            //{
                UnityEngine.SceneManagement.SceneManager.LoadScene("Lobby");
            //}*/
            //UnityEngine.SceneManagement.SceneManager.LoadScene("Lobby");
            //SceneManager.LoadScene("GameOver");
            //StartCoroutine(Load());
            player.GetComponent<PlayerControllerNetwork>().LeaveRoom();
        }

        public override void OnLeftRoom()
        {

            //SceneManager.LoadScene("GameOver");

            //PhotonNetwork.Disconnect();
            //StartCoroutine(Load());
        }

        private IEnumerator Load()
        {
            while (PhotonNetwork.IsConnected)
                yield return null;
            SceneManager.LoadScene("GameOver");
        }
        /*public override void OnMasterClientSwitched(Player newMasterClient)
        {
            if (PhotonNetwork.LocalPlayer.ActorNumber == newMasterClient.ActorNumber)
            {
                
            }
        }

        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            
        }*/

        public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
        {
            /*if (changedProps.ContainsKey(AsteroidsGame.PLAYER_LIVES))
            {
                CheckEndOfGame();
                return;
            }*/
            if (targetPlayer.GetPlayerNumber() == PhotonNetwork.LocalPlayer.GetPlayerNumber())
            {
                if (changedProps.ContainsKey(GameStateInfo.POSITION))
                {
                    object playerPosition;
                    targetPlayer.CustomProperties.TryGetValue(GameStateInfo.POSITION, out playerPosition);
                    controller.AssignPositionGUI((int)playerPosition);

                    //ES AQUÍ
                    FindObjectOfType<PlayerInfo>().finalPos = (int)playerPosition;
                }
            }


            if (!PhotonNetwork.IsMasterClient)
            {
                return;
            }
            if (changedProps.ContainsKey(GameStateInfo.EXIT_GAME)) {

                object hasExitedGame;
                targetPlayer.CustomProperties.TryGetValue(GameStateInfo.EXIT_GAME, out hasExitedGame);
                if (!(bool)hasExitedGame)
                {
                    playerDistances[targetPlayer.GetPlayerNumber()] = 0;
                }
            }
            if (changedProps.ContainsKey(GameStateInfo.CURRENT_DISTANCE))
            {
                int position = GetCurrentPosition(targetPlayer);
                Hashtable props = new Hashtable
                    {
                        {GameStateInfo.POSITION, position}
                    };
                targetPlayer.SetCustomProperties(props);
                //Debug.Log("[MASTER_CLIENT]For player: " + targetPlayer.GetPlayerNumber() + " position: " + position);
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

        //OnPhotonPlayerDisconnected(PhotonPlayer otherPlayer)
        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            base.OnPlayerLeftRoom(otherPlayer);
            if(PhotonNetwork.IsMasterClient)
            {
                Hashtable props = new Hashtable
                    {
                        {GameStateInfo.CURRENT_DISTANCE, 0}
                    };
                otherPlayer.SetCustomProperties(props);
                playerDistances[otherPlayer.GetPlayerNumber()] = 0;
            }
        }

        #endregion

        private void StartGame()
        {
            int playerNumber = PhotonNetwork.LocalPlayer.GetPlayerNumber();
            Debug.Log("EEEEEEEEEEEEEEEEEEEE" + playerNumber);
            Vector3 position = startingPositions[playerNumber].position;

            //Vector3 position = new Vector3(playerNumber * 3 - 3, 0.5f, 0.0f);

            string vehicleName = "CarNetwork";

            if (isDebug)
            {
                vehicleName = ChooseVehicle();
            }

            object[] data = new object[1];
            data[0] = playerNumber;
            player = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", vehicleName), position, Quaternion.identity, 0,data);

            //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"), position, Quaternion.identity, 0);

            player.GetComponent<InputedMovement>().SetCarCamera(mainCamera);
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

        private int GetCurrentPosition(Player player)
        {
            object currentDistance;
            int playerNumber = player.GetPlayerNumber();
            player.CustomProperties.TryGetValue(GameStateInfo.CURRENT_DISTANCE, out currentDistance);
            if(playerNumber < 0 || playerNumber > playerDistances.Length)
            {
                return playerDistances.Length;
            }
            playerDistances[playerNumber] = (float)currentDistance;
            int position = 1;
            for(int i = 0; i < playerDistances.Length; i++)
            {
                if(i != playerNumber)
                {
                    if((float)currentDistance > playerDistances[i] && playerDistances[i] > 0 && !PhotonNetwork.PlayerList[i].IsInactive)
                    {
                       
                        position++;
                    }
                }
            }

            return position;
        }
    }
}