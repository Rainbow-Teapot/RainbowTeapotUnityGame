using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum powerDown {TEAPOT, DALSY, TURBO_BACK, PARACHUTE, LEGO};

public class PowerDownBox : MonoBehaviour, IObstacle
{
   
    public void ApplyEffect(CarMovement car)
    {
        PowerDownUser user = car.GetComponent<PowerDownUser>();
        user.pickPowerDown();
        Destroy(gameObject);
    }

    public void DeApplyEffect(CarMovement car)
    {
        throw new System.NotImplementedException();
    }

}
