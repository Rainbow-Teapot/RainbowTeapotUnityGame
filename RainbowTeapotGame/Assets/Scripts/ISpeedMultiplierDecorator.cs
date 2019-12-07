using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedMultiplierDecorator
{
    private float speedMultiplier;

    public SpeedMultiplierDecorator(float speedMultiplier)
    {
        this.speedMultiplier = speedMultiplier;
    }

    public float ComputeSpeedMultiplier()
    {
        return speedMultiplier;
    }
}

