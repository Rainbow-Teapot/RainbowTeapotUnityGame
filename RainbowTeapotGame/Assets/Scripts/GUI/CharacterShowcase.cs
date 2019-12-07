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

    [SerializeField]
    private float maxRotationSpeed;
    [SerializeField]
    private float minRotationSpeed;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private float approachMultiplier;

    [SerializeField]
    private float rotationSpeedDrag = 40.0f;
    [SerializeField]
    private float lerpSpeed = 1.0f;
    private float xDeg;

    // Start is called before the first frame update
    void Start()
    {
        playerInfo = GameObject.Find("PlayerInfo").GetComponent<PlayerInfo>();

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

        if (Input.GetMouseButton(0))
        {
            xDeg -= Input.GetAxis("Mouse X") * rotationSpeedDrag;
            //yDeg += Input.GetAxis("Mouse Y") * speed * friction;
            Quaternion fromRotation = transform.rotation;
            Quaternion toRotation = Quaternion.Euler(0, xDeg, 0);
            transform.rotation = Quaternion.Lerp(fromRotation, toRotation, Time.deltaTime * lerpSpeed);
            rotationSpeed = minRotationSpeed;
        }
        else { 

            if (rotationSpeed > minRotationSpeed)
            {
                rotationSpeed -= approachMultiplier;
            }
            else
            {
                rotationSpeed = minRotationSpeed;
            }

            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }

    public void NextVehicle()
    {
        carPicked = (vehicles)(((int)carPicked + 1) % carShowcasePrebaf.Length);        
        FindObjectOfType<AudioManager>().Character(carPicked.ToString());
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
        FindObjectOfType<AudioManager>().Character(carPicked.ToString());
        SwapVehicle();
    }

    private void SwapVehicle()
    {
        Debug.Log(carPicked);
        transform.rotation = Quaternion.identity;
        playerInfo.vehiclePicked = carPicked;
        rotationSpeed = maxRotationSpeed;

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
        transform.rotation = Quaternion.identity;
        rotationSpeed = maxRotationSpeed;
        if (carShowcased != null)
        {
            carShowcased.transform.position = hiddenPosition.position;
        }
        carShowcased = carShowcaseObjects[(int)carPicked];
        carShowcased.transform.position = showcasePosition.position;
       
    }

}
