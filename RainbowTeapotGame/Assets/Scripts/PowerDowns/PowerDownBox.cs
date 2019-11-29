using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum powerDown {TEAPOT, DALSY, TURBO_BACK, PARACHUTE, LEGO};

public class PowerDownBox : MonoBehaviour, IObstacle
{
    [SerializeField]
    private GameObject[] powerDowns;


    public void ApplyEffect(CarMovement car)
    {
        PowerDownUser user = car.GetComponent<PowerDownUser>();
        if(user != null)
            user.SetCurrentPowerDown(PickPowerDown(0));
        Destroy(gameObject);
     
    }

    public void DeApplyEffect(CarMovement car)
    {
        //throw new System.NotImplementedException();
    }

    private IPowerDown PickPowerDown(int position)
    {
        return powerDowns[Random.Range(0,powerDowns.Length)].GetComponent<IPowerDown>();
    }

}
