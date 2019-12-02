using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public vehicles vehiclePicked;
    public bool online = false;
    public bool hasBeenLogged = false;
    public int lang;
    

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

        lang = 1;
    }
}
