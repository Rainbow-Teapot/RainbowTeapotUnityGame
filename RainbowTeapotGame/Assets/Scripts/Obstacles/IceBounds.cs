using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBounds : MonoBehaviour, IObstacle
{
    [SerializeField]
    private int facingToChange;

    public void ApplyEffect(CarMovement car)
    {
        if(car.GetCurrentCarState() == carStates.ZIGZAG && car.GetHorFacing() != facingToChange)
            car.OppositeHorDirection();
    }

    public void DeApplyEffect(CarMovement car)
    {
        
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
