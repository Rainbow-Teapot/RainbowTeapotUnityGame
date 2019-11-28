using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShowcase : MonoBehaviour
{
    [SerializeField]
    private GameObject[] carShowcasePrebaf;

    private GameObject[] carShowcaseObjects;

    private GameObject carShowcased;
    public vehicles carPicked { get; set; }

    [SerializeField]
    private Transform showcasePosition;
    [SerializeField]
    private Transform hiddenPosition;

    [SerializeField]
    private float scaleFactor;

    [SerializeField]
    private PlayerInfo playerInfo;

    // Start is called before the first frame update
    void Start()
    {
        carShowcaseObjects = new GameObject[carShowcasePrebaf.Length];

        int i = 0;

        foreach(GameObject car in carShowcasePrebaf)
        {
            carShowcaseObjects[i] = Instantiate(car, hiddenPosition.position, Quaternion.Euler(0,180,0));
            carShowcaseObjects[i].transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
            carShowcaseObjects[i].transform.parent = transform;
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //rotacion
    }

    public void NextVehicle()
    {
        carPicked = (vehicles)(((int)carPicked + 1) % carShowcasePrebaf.Length);
        SwapVehicle();
    }

    public void PreviousVehicle()
    {

        int value = 0;

        if (carPicked == 0)
        {
            value = carShowcasePrebaf.Length - 1;
        }
        else {
            value = (((int)carPicked - 1) % carShowcasePrebaf.Length);
        }

        carPicked = (vehicles)value;
        SwapVehicle();
    }

    private void SwapVehicle()
    {
        Debug.Log(carPicked);
        playerInfo.vehiclePicked = carPicked;


        if (carShowcased != null)
        {
            carShowcased.transform.position = hiddenPosition.position;
            carShowcased = carShowcaseObjects[(int)carPicked];
        }
        else
        {
            carShowcased = carShowcaseObjects[(int)carPicked];
        }

        carShowcased.transform.position = showcasePosition.position;
    }

    public void SetCarPicked(vehicles carPicked)
    {
        this.carPicked = carPicked;
        if(carShowcased != null)
        {
            carShowcased.transform.position = hiddenPosition.position;
        }
        carShowcased = carShowcaseObjects[(int)carPicked];
        carShowcased.transform.position = showcasePosition.position;
       
    }

}
