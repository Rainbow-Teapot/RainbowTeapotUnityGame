using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurboBackPower : MonoBehaviour, IPowerDown
{
    [SerializeField]
    private GameObject turboPrefab;

    public void Activate(CarMovement car)
    {
        Debug.Log("[POWER-DOWN]: " + name);
        if (!car.GetComponent<PlayerControllerNetwork>())
        {
            GameObject turbo = Instantiate(turboPrefab, car.transform.position + Vector3.down * 0.25f + Vector3.up, Quaternion.identity);
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
