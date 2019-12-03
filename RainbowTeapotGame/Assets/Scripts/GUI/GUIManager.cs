using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{

    [SerializeField]
    private GameObject optionsInGamePanel;

    public Sprite tick;
    public Sprite tickOK;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
