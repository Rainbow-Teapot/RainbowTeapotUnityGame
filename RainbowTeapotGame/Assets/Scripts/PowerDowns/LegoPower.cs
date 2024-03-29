﻿using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LegoPower : MonoBehaviour, IPowerDown
{
    [SerializeField]
    private GameObject legoPrefab;

    private string audioclip = "Lego";

    public void Activate(CarMovement car)
    {
        Debug.Log("[POWER-DOWN]: " + name);

        Vector3 posToSpawn = car.transform.position + Vector3.back * 3.5f;

        car.GetComponent<PowerDownUser>().ResetPowerDown();
        

        if (!car.GetComponent<PlayerControllerNetwork>())
        {
            Instantiate(legoPrefab, posToSpawn, Quaternion.identity);
        }
        else
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "LegoNetwork"), posToSpawn, Quaternion.identity, 0);

        }
    }
}
