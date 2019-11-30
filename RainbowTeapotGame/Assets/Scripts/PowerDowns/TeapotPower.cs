using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TeapotPower : MonoBehaviour, IPowerDown
{
    [SerializeField]
    private GameObject teapotPrefab;

    public void Activate(CarMovement car)
    {
        Debug.Log("[POWER-DOWN]: " + name);
        Vector3 posToSpawn = car.transform.position + Vector3.up * 1.25f + Vector3.back * 2f;
        
        if (!car.GetComponent<PlayerControllerNetwork>())
        {
            
            Instantiate(teapotPrefab, posToSpawn, Quaternion.identity);
        }
        else
        {
           
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "TeapotNetwork"), posToSpawn, Quaternion.identity, 0);
            
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
