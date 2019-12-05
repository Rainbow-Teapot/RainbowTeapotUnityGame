using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour, IObstacle
{
    [SerializeField]
    private float speedMultiplier = 1.55f;

    private SpeedMultiplierDecorator iceDecorator;

    private void Start()
    {
        iceDecorator = new SpeedMultiplierDecorator(speedMultiplier);
    }

    public void ApplyEffect(CarMovement car)
    {
        //car.SetSpeedMultiplier(1.25f);
        FindObjectOfType<AudioManager>().Play("Ice");
        if (!car.GetSpeedMultiplierDecorators().Contains(iceDecorator))
        {
            car.AddSpeedDecorator(iceDecorator);
            car.SetCurrentCarState(carStates.ZIGZAG);
        }
    }

    public void DeApplyEffect(CarMovement car)
    {
        //car.SetSpeedMultiplier(1.0f);
        
        car.RemoveSpeedDecorator(iceDecorator);
        car.SetCurrentCarState(carStates.IDLE);
    }

}
