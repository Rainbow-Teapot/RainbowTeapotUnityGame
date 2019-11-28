using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public vehicles vehiclePicked;
    public bool online = false;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }
}
