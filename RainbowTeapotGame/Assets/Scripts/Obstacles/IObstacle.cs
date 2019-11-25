using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObstacle
{
    void ApplyEffect(CarMovement car);
    void DeApplyEffect(CarMovement car);
}
