﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum vehicles { Carrito, Naranjita, Patin, Vaca, Vater,Telefono };

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

    private PlayerInfo playerInfo;

    // Start is called before the first frame update
    void Start()
    {

        playerInfo = GameObject.Find("PlayerInfo").GetComponent<PlayerInfo>();

        GameObject vehicle;
        if (!isDebug)
        {
            vehicle = Instantiate(carPrefabs[Random.Range(0, carPrefabs.Length - 1)], startingPos.position, Quaternion.identity);
        }
        else
        {
            vehicle = Instantiate(carPrefabs[(int)playerInfo.vehiclePicked], startingPos.position, Quaternion.identity);

        }
        InputedMovement inputedCar = vehicle.GetComponent<InputedMovement>();
        if(inputedCar != null)
            inputedCar.SetCarCamera(mainCamera);
        CameraController cameraController = mainCamera.GetComponent<CameraController>();
        if(cameraController != null)
            cameraController.setTarget(vehicle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
