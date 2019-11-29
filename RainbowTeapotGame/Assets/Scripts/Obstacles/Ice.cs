using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour, IObstacle
{
    public void ApplyEffect(CarMovement car)
    {
        car.SetSpeedMultiplier(1.25f);
        car.SetCurrentCarState(carStates.ZIGZAG);
    }

    public void DeApplyEffect(CarMovement car)
    {
        car.SetSpeedMultiplier(1.0f);
        car.SetCurrentCarState(carStates.IDLE);
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
