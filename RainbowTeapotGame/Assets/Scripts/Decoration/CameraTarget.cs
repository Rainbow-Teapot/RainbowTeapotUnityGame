using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    public float speed { get; set; }

    private CarMovement car;

    private void Awake()
    {
        speed = 0.0f;
        car = GetComponent<CarMovement>();
    }

    private void Update()
    {
        if (car)
        {
            speed = car.velZ;
        }
    }
}
