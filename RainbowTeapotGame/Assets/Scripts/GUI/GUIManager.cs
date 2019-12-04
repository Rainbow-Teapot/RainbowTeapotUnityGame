using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GUIManager : MonoBehaviour
{

    [SerializeField]
    private GameObject optionsInGamePanel;

    public Sprite tick;
    public Sprite tickOK;
    public Button buttonSound;
    public Button buttonMusic;

    public TextMeshProUGUI soundText;
    public TextMeshProUGUI musicText;
    public TextMeshProUGUI leaveGameText;
    public TextMeshProUGUI optionsText; 


    public LanguageManager lang = new LanguageManager(); 

    public string levelMusicName;

    public void OnOptionsButtonCliked()
    {
        optionsInGamePanel.SetActive(true);
    }

    public void OnBackButtonClicked()
    {
        optionsInGamePanel.SetActive(false);
    }

    public void OnMusicButtonClicked(Button button)
    {
        FindObjectOfType<PlayerInfo>().musicOn = (!FindObjectOfType<PlayerInfo>().musicOn);
        button.image.overrideSprite = FindObjectOfType<PlayerInfo>().musicOn ? tickOK : tick;
        FindObjectOfType<MusicManager>().PlayOrPause(levelMusicName);
    }

    public void OnSoundButtonClicked(Button button)
    {
        FindObjectOfType<PlayerInfo>().soundsOn = (!FindObjectOfType<PlayerInfo>().soundsOn);
        button.image.overrideSprite = FindObjectOfType<PlayerInfo>().soundsOn ? tickOK : tick;
    }

    private void Awake()
    {
        updateTexts();
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateTexts() {
        buttonMusic.image.overrideSprite = FindObjectOfType<PlayerInfo>().musicOn ? tickOK : tick;
        buttonSound.image.overrideSprite = FindObjectOfType<PlayerInfo>().soundsOn ? tickOK : tick;

        musicText.text = lang.getText(FindObjectOfType<PlayerInfo>().lang, 7);
        soundText.text = lang.getText(FindObjectOfType<PlayerInfo>().lang, 8);
        leaveGameText.text = lang.getText(FindObjectOfType<PlayerInfo>().lang, 13);
        optionsText.text = lang.getText(FindObjectOfType<PlayerInfo>().lang, 21);

    }
}
