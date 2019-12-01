using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mud : MonoBehaviour, IObstacle
{
    [SerializeField]
    private float speedMultiplier = 0.45f;

    private SpeedMultiplierDecorator mudDecorator;
    private bool runOver = false;


    private void Start()
    {
        mudDecorator = new SpeedMultiplierDecorator(speedMultiplier);
    }

    public void ApplyEffect(CarMovement car)
    {
        //if(car.GetSpeedMultiplier() > speedMultiplier)
        //car.SetSpeedMultiplier(speedMultiplier);
        if (!car.GetSpeedMultiplierDecorators().Contains(mudDecorator))
        {
            car.AddSpeedDecorator(mudDecorator);
            
        }
        
    }

    public void DeApplyEffect(CarMovement car)
    {

        //car.SetSpeedMultiplier(1.0f);
        
        car.RemoveSpeedDecorator(mudDecorator);
    }

    
}
