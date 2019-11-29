using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeapotPower : MonoBehaviour, IPowerDown
{
    [SerializeField]
    private GameObject teapotPrefab;

    public void Activate(CarMovement car)
    {
        Debug.Log("[POWER-DOWN]: " + name);
        Instantiate(teapotPrefab, car.transform.position + Vector3.up * 1.25f + Vector3.back * 2f, Quaternion.identity);
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
