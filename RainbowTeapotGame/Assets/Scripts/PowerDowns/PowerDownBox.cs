using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum powerDown {TEAPOT, DALSY, TURBO_BACK, PARACHUTE, LEGO};

public class PowerDownBox : MonoBehaviour, IObstacle
{
    [SerializeField]
    private GameObject[] powerDowns;

    private bool hasCrashed = false;

    public void ApplyEffect(CarMovement car)
    {
        //FindObjectOfType<AudioManager>().Character(FindObjectOfType<PlayerInfo>().vehiclePicked.ToString());
        if (!hasCrashed)
        {
            hasCrashed = true;
            PowerDownUser user = car.GetComponent<PowerDownUser>();
            //avisar al usuario de que avise al controlador para iniciar la ruleta, se le pasa también
            //el power up que ha salido
            if (user != null)
            {
                //user.SetCurrentPowerDown(PickPowerDown(0));
                int id = Random.Range(0, powerDowns.Length);
                //Debug.Log("Ha tocado: " + ((powerDown)id).ToString());
                user.PowerDownBoxPicked(PickPowerDown(0, id), (powerDown)id);
            }
            Destroy(gameObject);
        }
    }

    public void DeApplyEffect(CarMovement car)
    {
        //throw new System.NotImplementedException();
    }

    private IPowerDown PickPowerDown(int position,int id)
    {
        return powerDowns[id].GetComponent<IPowerDown>();
    }

}
