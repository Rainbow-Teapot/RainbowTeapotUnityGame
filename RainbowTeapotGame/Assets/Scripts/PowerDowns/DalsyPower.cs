using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DalsyPower : MonoBehaviour, IPowerDown
{
    [SerializeField]
    private GameObject dalsyPrefab;

    public void Activate(CarMovement car)
    {
        Debug.Log("[POWER-DOWN]: " + name);
        Dalsy dalsy = Instantiate(dalsyPrefab, Vector3.zero, Quaternion.identity).GetComponent<Dalsy>();
        dalsy.car = car;


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
