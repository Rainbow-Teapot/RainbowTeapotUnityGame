using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{

    public TextMeshProUGUI backToMenu;
    public PlayerInfo playerInfo;
    

    [SerializeField]
    private Sprite[] positionImages;

    [SerializeField]
    private Image currentPositionImage;

    LanguageManager lang = new LanguageManager(); 

    public void Start()
    {
        playerInfo = GameObject.Find("PlayerInfo").GetComponent<PlayerInfo>();
        backToMenu.text = lang.getText(playerInfo.lang, 18);

        if (playerInfo.hasFinishRace)
            currentPositionImage.sprite = positionImages[playerInfo.finalPos - 1];
        else {
            currentPositionImage.enabled = false;
        }

    }

    public void OnReturnToMenuButtonClicked()
    {
        SceneManager.LoadScene("Lobby");
    }
}
