using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mug : MonoBehaviour, IObstacle
{
    [SerializeField]
    private float speedMultiplier = 0.45f;

    public void ApplyEffect(CarMovement car)
    {
        Debug.Log("Reduzco la velocidad");
        car.SetSpeedMultiplier(speedMultiplier);
    }

    public void DeApplyEffect(CarMovement car)
    {
        
        car.SetSpeedMultiplier(1.0f);
    }
}
