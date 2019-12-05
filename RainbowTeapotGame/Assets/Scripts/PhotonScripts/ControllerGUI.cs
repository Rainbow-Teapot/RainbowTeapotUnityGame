using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerGUI : MonoBehaviour
{

    [SerializeField]
    private Sprite[] positionImages;

    [SerializeField]
    private Image currentPositionImage;

    [SerializeField]
    private Image currentPowerDownImage;

    [SerializeField]
    private GameObject miniaturePrefab;

    [SerializeField]
    private GameObject minimap;

    public PowerDownUser user { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AssignPositionGUI(int position)
    {
        
        currentPositionImage.sprite = positionImages[position - 1];
    }

    public void InitGamblingEffectGUI(powerDown powerID)
    {
        FindObjectOfType<AudioManager>().Play("PowerDown");
        currentPowerDownImage.GetComponent<SpinGamblingEfect>().GamblingEffect(powerID);
    }

    public void FinishGambling()
    {
        user.CanUsePowerDown();
    }

    public void WipeOutPowerDown()
    {
        currentPowerDownImage.GetComponent<SpinGamblingEfect>().ClearImage();
    }

    public MinimapMiniature CreateMinimapMiniature(vehicles vehicle, bool isMine)
    {
        MinimapMiniature miniatureObj = Instantiate(miniaturePrefab, minimap.transform).GetComponent<MinimapMiniature>();
        miniatureObj.Init(vehicle, isMine);
        return miniatureObj;
    }
}
