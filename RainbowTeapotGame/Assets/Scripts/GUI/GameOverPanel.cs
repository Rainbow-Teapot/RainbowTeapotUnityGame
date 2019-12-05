﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using Photon.Pun;

public class GameOverPanel : MonoBehaviour
{

    public TextMeshProUGUI backToMenu;
    public PlayerInfo playerInfo;
    public Text text1;
    public Text text2;
    

    [SerializeField]
    private Sprite[] positionImages;

    [SerializeField]
    private Image currentPositionImage;

    [SerializeField]
    private GameObject[] carShowcasePrebaf;
    private GameObject carShowcaseObject;

    [SerializeField]
    private Transform PositionAppear;



    LanguageManager lang = new LanguageManager(); 

    public void Start()
    {
        playerInfo = GameObject.Find("PlayerInfo").GetComponent<PlayerInfo>();
        backToMenu.text = lang.getText(playerInfo.lang, 18);

        if (playerInfo.hasFinishRace)
        {
            currentPositionImage.sprite = positionImages[playerInfo.finalPos - 1];
            
        }
        else
        {
            currentPositionImage.enabled = false;
            text1.gameObject.SetActive(true);
            text2.text = lang.getText(playerInfo.lang, 23);
            text2.gameObject.SetActive(true);
        }

        GameObject car = carShowcasePrebaf[(int)playerInfo.vehiclePicked];
        carShowcaseObject = Instantiate(car, PositionAppear.position, Quaternion.Euler(0, 200, 0));
       


    }

    public void OnReturnToMenuButtonClicked()
    {
        if(!PhotonNetwork.IsConnected)
            PhotonNetwork.ConnectUsingSettings();
        SceneManager.LoadScene("Lobby");
    }
}