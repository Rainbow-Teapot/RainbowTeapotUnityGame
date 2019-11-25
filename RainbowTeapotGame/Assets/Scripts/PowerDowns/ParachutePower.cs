using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParachutePower : MonoBehaviour, IPowerDown
{
    public void Activate(CarMovement car)
    {
        Debug.Log("[POWER-DOWN]: " + name);
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
