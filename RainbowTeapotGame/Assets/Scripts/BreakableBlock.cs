﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBlock : MonoBehaviour,IObstacle
{
    [SerializeField]
    private float speedMultiplier = 0.25f;

    public void ApplyEffect(CarMovement car)
    {
        car.SetSpeedMultiplier(speedMultiplier);
        car.SetCurrentCarState(carStates.IDLE);
        Destroy(gameObject);
    }

    public void DeApplyEffect(CarMovement car)
    {
        //throw new System.NotImplementedException();
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
