using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum vehicles { Carrito, Naranjita, Vater, Telefono, Vaca };

public class CarSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] carPrefabs;

    [SerializeField]
    private Transform startingPos;

    [SerializeField]
    private Camera mainCamera;

    public vehicles vehiclePicked;
    public bool isDebug = true;

    // Start is called before the first frame update
    void Start()
    {
        GameObject vehicle;
        if (!isDebug)
        {
            vehicle = Instantiate(carPrefabs[Random.Range(0, carPrefabs.Length - 1)], startingPos.position, Quaternion.identity);
        }
        else
        {
            vehicle = Instantiate(carPrefabs[(int)vehiclePicked], startingPos.position, Quaternion.identity);

        }
        InputedMovement inputedCar = vehicle.GetComponent<InputedMovement>();
        inputedCar.SetCarCamera(mainCamera);
        CameraController cameraController = mainCamera.GetComponent<CameraController>();
        cameraController.setTarget(vehicle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
