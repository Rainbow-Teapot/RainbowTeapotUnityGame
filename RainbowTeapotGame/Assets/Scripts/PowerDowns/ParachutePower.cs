using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParachutePower : MonoBehaviour, IPowerDown
{
    [SerializeField]
    private GameObject parachutePrefab;

    public void Activate(CarMovement car)
    {
        Debug.Log("[POWER-DOWN]: " + name);
        Parachute parachute = Instantiate(parachutePrefab, car.transform.position + new Vector3(0,1,1),Quaternion.identity).GetComponent<Parachute>();
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
