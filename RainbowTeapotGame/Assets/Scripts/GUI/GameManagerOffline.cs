using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerOffline : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;
    private GameObject player;

    [SerializeField]
    private GameObject[] vehiclesPrefabs;
    private List<GameObject> vehiclesIAs = new List<GameObject>();

    [SerializeField]
    private Transform[] startingPositions;

    [SerializeField]
    private ControllerGUI controller;

    private readonly int MAX_VECHICLES = 5;

    public vehicles vehiclePicked;

    private float[] playerDistances;

    private PlayerInfo playerInfo;


    // Start is called before the first frame update
    void Start()
    {
        playerInfo = GameObject.Find("PlayerInfo").GetComponent<PlayerInfo>();
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartGame()
    {
        vehicles vehiclePicked = playerInfo.vehiclePicked;

        player = Instantiate(vehiclesPrefabs[(int)vehiclePicked], startingPositions[0].position, Quaternion.identity);
        mainCamera.GetComponent<CameraController>().setTarget(player);
        

        for(int i = 0; i < 6; i++)
        {
            if((int)vehiclePicked != i){
                GameObject iaCar = Instantiate(vehiclesPrefabs[i], startingPositions[i + 1].position, Quaternion.identity);
                iaCar.GetComponent<InputedMovement>().enabled = false;
                iaCar.GetComponent<DoubleClickChecker>().enabled = false;
                iaCar.GetComponent<PowerDownUser>().enabled = false;
                vehiclesIAs.Add(iaCar);
            }
        }
    }
}
