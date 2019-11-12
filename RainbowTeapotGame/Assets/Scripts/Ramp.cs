using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramp : MonoBehaviour, IObstacle
{
    [SerializeField]
    private float speedMultiplier = 1.6f;

    public void ApplyEffect(CarMovement car)
    {
        Debug.Log("Estoy acelerando: ");
        //car.SetSpeedMultiplier(speedMultiplier);
        car.Boost();
    }

    public void DeApplyEffect(CarMovement car)
    {
        //throw new System.NotImplementedException();
    }
}
