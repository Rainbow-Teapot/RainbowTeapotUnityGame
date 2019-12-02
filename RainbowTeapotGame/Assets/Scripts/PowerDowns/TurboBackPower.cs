using Photon.Pun;
using Photon.Pun.UtilityScripts;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TurboBackPower : MonoBehaviour, IPowerDown
{
    [SerializeField]
    private GameObject turboPrefab;

    public void Activate(CarMovement car)
    {
        Vector3 posToSpawn = car.transform.position + Vector3.down * 0.50f + Vector3.up;

        car.GetComponent<PowerDownUser>().ResetPowerDown();
       

        Debug.Log("[POWER-DOWN]: " + name);
        if (!car.GetComponent<PlayerControllerNetwork>())
        {
            GameObject turbo = Instantiate(turboPrefab, posToSpawn, Quaternion.identity);
            TurboBack turboBack = turbo.GetComponent<TurboBack>();
            turboBack.ownerCar = car;
        }
        else
        {
            object[] data = new object[1];
            data[0] = PhotonNetwork.LocalPlayer.GetPlayerNumber();
            GameObject turbo = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "TurboBackNetwork"), posToSpawn, Quaternion.identity, 0, data);
            TurboBack turboBack = turbo.GetComponent<TurboBack>();
            turboBack.ownerCar = car;
        }
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
