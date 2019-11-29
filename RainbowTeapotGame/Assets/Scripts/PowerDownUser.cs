using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DoubleClickChecker))]
public class PowerDownUser : MonoBehaviour
{
    //private powerDown currentPowerDown;

    private IPowerDown currentPowerDown = null;
    private DoubleClickChecker dbChecker;
    private CarMovement car;

    public bool isDebug = true;
    public GameObject[] powerDownsToDebug;

    private void Awake()
    {
        dbChecker = GetComponent<DoubleClickChecker>();
        car = GetComponent<CarMovement>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dbChecker.HasBeenDoubleClick())
        {
            usePowerDown();
        }   
    }


    private void usePowerDown()
    {
        if(currentPowerDown != null)
        {
            currentPowerDown.Activate(car);
            currentPowerDown = null;
        }
    }

    public void SetCurrentPowerDown(IPowerDown currentPowerDown)
    {   
        if (this.currentPowerDown == null)
        {
            if(!isDebug)
                this.currentPowerDown = currentPowerDown;
            else
                this.currentPowerDown = powerDownsToDebug[0].GetComponent<IPowerDown>();
        }   
    }
}
