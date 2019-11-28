using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public vehicles vehiclePicked;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }
}
