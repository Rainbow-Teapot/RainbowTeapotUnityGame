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
    [SerializeField]
    private bool powerDownActivated;

    private ControllerGUI controller;
    [SerializeField]
    private bool canUsePowerDown;

    private void Awake()
    {
        dbChecker = GetComponent<DoubleClickChecker>();
        car = GetComponent<CarMovement>();
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("ControllerGUI").GetComponent<ControllerGUI>();
        controller.user = this;
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
        if(currentPowerDown != null && !powerDownActivated && canUsePowerDown)
        {
            powerDownActivated = true;
            currentPowerDown.Activate(car);
        }
        if(powerDownActivated)
        {
            Debug.Log("NOOO, ya lo usé");
        }
        if (!canUsePowerDown)
        {
            Debug.Log("NOOO, aun no puedes usarlo");

        }
        if (currentPowerDown == null) {
            Debug.Log("NOOOO, aun no lo tienes");
        }
    }

    public void ResetPowerDown()
    {
        currentPowerDown = null;
        powerDownActivated = false;
        controller.WipeOutPowerDown();
        //avisar al controllador de poner en alpha la imagen del powerdown
    }

    public void SetCurrentPowerDown(IPowerDown currentPowerDown)
    {
        canUsePowerDown = false;
        this.currentPowerDown = currentPowerDown;

    }
    public void CanUsePowerDown()
    {
        canUsePowerDown = true;
    }

    public void PowerDownBoxPicked(IPowerDown powerDown, powerDown powerID)
    {
        if (this.currentPowerDown == null)
        {
            SetCurrentPowerDown(powerDown);
            Debug.Log("[PLAYER]: TENEMOS EL " + powerID.ToString());
            controller.InitGamblingEffectGUI(powerID);
        }

    }
}
