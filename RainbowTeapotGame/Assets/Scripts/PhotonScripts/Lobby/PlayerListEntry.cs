// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlayerListEntry.cs" company="Exit Games GmbH">
//   Part of: Asteroid Demo,
// </copyright>
// <summary>
//  Player List Entry
// </summary>
// <author>developer@exitgames.com</author>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.UI;

using ExitGames.Client.Photon;
using Photon.Realtime;
using Photon.Pun.UtilityScripts;

namespace Photon.Pun.Demo.Asteroids
{
    public class PlayerListEntry : MonoBehaviour
    {
        [Header("UI References")]
        public Text PlayerNameText;

        [Header("Vehicles Images")]
        [SerializeField]
        private Sprite[] vehiclesImages;

        

        public Image PlayerColorImage;
        public Button PlayerReadyButton;
        public Image PlayerReadyImage;
        public Sprite tick;
        public Sprite tickOK;

        private int ownerId;
        private bool isPlayerReady;

        private PlayerInfo playerInfo;
        
        #region UNITY

        public void OnEnable()
        {
            playerInfo = GameObject.Find("PlayerInfo").GetComponent<PlayerInfo>();
            Hashtable props = new Hashtable() {{ GameStateInfo.VEHICLE, playerInfo.vehiclePicked} };
            PhotonNetwork.LocalPlayer.SetCustomProperties(props);
            PlayerNumbering.OnPlayerNumberingChanged += OnPlayerNumberingChanged;
        }

        public void Start()
        {
            
            if (PhotonNetwork.LocalPlayer.ActorNumber != ownerId)
            {
                PlayerReadyButton.gameObject.SetActive(false);
            }
            else
            {
                PlayerReadyImage.gameObject.SetActive(false);
                Hashtable initialProps = new Hashtable() {{GameStateInfo.PLAYER_READY, isPlayerReady}};
                PhotonNetwork.LocalPlayer.SetCustomProperties(initialProps);
                PhotonNetwork.LocalPlayer.SetScore(0);

                PlayerReadyButton.onClick.AddListener(() =>
                {
                    isPlayerReady = !isPlayerReady;
                    SetPlayerReady(isPlayerReady);

                    Hashtable props = new Hashtable() {{GameStateInfo.PLAYER_READY, isPlayerReady} };
                    PhotonNetwork.LocalPlayer.SetCustomProperties(props);

                    if (PhotonNetwork.IsMasterClient)
                    {
                        FindObjectOfType<LobbyMainPanel>().LocalPlayerPropertiesUpdated();
                    }
                });
            }
        }

        public void OnDisable()
        {
            PlayerNumbering.OnPlayerNumberingChanged -= OnPlayerNumberingChanged;
        }

        #endregion

        public void Initialize(int playerId, string playerName)
        {
            ownerId = playerId;
            PlayerNameText.text = playerName;
        }

        private void OnPlayerNumberingChanged()
        {
            foreach (Player p in PhotonNetwork.PlayerList)
            {
                
                if (p.ActorNumber == ownerId)
                {
                    //PlayerColorImage.color = GameStateInfo.GetColor(p.GetPlayerNumber());
                    object playerVehicle;
                    if(p.CustomProperties.TryGetValue(GameStateInfo.VEHICLE, out playerVehicle))
                    PlayerColorImage.sprite = GetImageVehiclePicked((vehicles) playerVehicle);
                    PlayerColorImage.color = Color.white;
                }
            }
        }

        public void SetPlayerReady(bool playerReady)
        {
           // PlayerReadyButton.GetComponentInChildren<Text>().text = playerReady ? "Ready!" : "Ready?";
            PlayerReadyButton.image.overrideSprite = playerReady ? tickOK : tick;

            if (PhotonNetwork.LocalPlayer.ActorNumber != ownerId)
                PlayerReadyImage.enabled = playerReady;
        }

        private Sprite GetImageVehiclePicked(vehicles vehiclePicked)
        {
            return vehiclesImages[(int)vehiclePicked];
        }
    }
}