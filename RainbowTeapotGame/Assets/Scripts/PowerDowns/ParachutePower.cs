using Photon.Pun;
using Photon.Pun.UtilityScripts;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ParachutePower : MonoBehaviour, IPowerDown
{
    [SerializeField]
    private GameObject parachutePrefab;

    public void Activate(CarMovement car)
    {
        Debug.Log("[POWER-DOWN]: " + name);

        Vector3 posToSpawn = car.transform.position + new Vector3(0, 1, 3);
        Parachute parachute;

        if (!car.GetComponent<PlayerControllerNetwork>())
        {
            parachute = Instantiate(parachutePrefab,posToSpawn , Quaternion.identity).GetComponent<Parachute>();
        }
        else
        {
            object[] data = new object[1];
            data[0] = PhotonNetwork.LocalPlayer.GetPlayerNumber();
            GameObject para = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "ParachuteNetwork"), posToSpawn, Quaternion.identity, 0, data);
            parachute = para.GetComponent<Parachute>();
        }

        parachute.transform.parent = car.transform;
        parachute.car = car;
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
