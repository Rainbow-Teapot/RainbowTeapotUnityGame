using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverPanel : MonoBehaviour
{

    public TextMeshProUGUI backToMenu;
    public PlayerInfo playerInfo;
    public ControllerGUI controllerGUI;
    LanguageManager lang = new LanguageManager(); 

    public void Start()
    {
        playerInfo = GameObject.Find("PlayerInfo").GetComponent<PlayerInfo>();
        backToMenu.text = lang.getText(playerInfo.lang, 18);

        if (playerInfo.hasFinishRace)
            controllerGUI.AssignPositionGUI(playerInfo.finalPos);
        
    }

    public void OnReturnToMenuButtonClicked()
    {
        SceneManager.LoadScene("Lobby");
    }
}
