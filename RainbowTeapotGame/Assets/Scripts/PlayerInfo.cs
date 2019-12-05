using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum levels {SNOWY_MOUNTAIN, CANDY, NIGHTMARES};

public class PlayerInfo : MonoBehaviour
{
    public vehicles vehiclePicked;
    public bool online = false;
    public bool hasBeenLogged = false;
    public int lang;
    public bool musicOn = true;
    public bool soundsOn = true;
    public bool hasFinishRace = false;
    public int finalPos = 0;
    public levels level;

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
