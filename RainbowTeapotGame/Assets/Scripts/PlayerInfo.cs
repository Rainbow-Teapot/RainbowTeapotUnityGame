using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public vehicles vehiclePicked;
    public bool online = false;
    public bool hasBeenLogged = false;
    public int lang;
    public bool musicOn = true;
    public bool soundsOn = true;
    public bool hasFinishRace = false;

    private void Awake()
    {
        GameObject playerInfo = GameObject.Find("PlayerInfo");
        if (playerInfo != gameObject)
        {
            Destroy(gameObject);
        }
        else { 
        DontDestroyOnLoad(this);
            }

        lang = 0;
    }
}
