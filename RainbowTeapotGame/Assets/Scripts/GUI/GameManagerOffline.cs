using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    [SerializeField]
    private GUIManager guiManager;

    [SerializeField]
    private Text textCountDown;
    [SerializeField]
    private int countDown;

    [SerializeField]
    private Transform endPosition;
    [SerializeField]
    private Transform startPosition;
    private Vector3 actualStartingPosition;

    private readonly int MAX_VECHICLES = 5;

    private float[] playerDistances;

    private PlayerInfo playerInfo;

    private MinimapMiniature playerMiniature;
    private List<MinimapMiniature> aiMiniatures = new List<MinimapMiniature>();

    // Start is called before the first frame update
    void Start()
    {
        actualStartingPosition = new Vector3(0, 0, startPosition.position.z);
        playerInfo = GameObject.Find("PlayerInfo").GetComponent<PlayerInfo>();
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        int playerPosition = CurrentPlayerPosition();
        playerInfo.finalPos = playerPosition;
        controller.AssignPositionGUI(playerPosition);
        AssignMiniaturesPosition();
        
    }

    private void StartGame()
    {
        vehicles vehiclePicked = playerInfo.vehiclePicked;

        player = Instantiate(vehiclesPrefabs[(int)vehiclePicked], startingPositions[0].position, Quaternion.Euler(0,180,0));
        player.GetComponent<CarMovement>().enabled = false;
        player.GetComponent<InputedMovement>().SetCarCamera(mainCamera);
        mainCamera.GetComponent<CameraController>().setTarget(player);
        playerMiniature = controller.CreateMinimapMiniature(vehiclePicked, true);

        int totalIaCars = 0;
        for(int i = 0; i < 6; i++)
        {
            if((int)vehiclePicked != i && totalIaCars < 4){
                GameObject iaCar = Instantiate(vehiclesPrefabs[i], startingPositions[totalIaCars+1].position, Quaternion.Euler(0, 180, 0));
                iaCar.GetComponent<InputedMovement>().enabled = false;
                iaCar.GetComponent<CarMovement>().enabled = false;
                iaCar.GetComponent<DoubleClickChecker>().enabled = false;
                iaCar.GetComponent<PowerDownUser>().enabled = false;
                aiMiniatures.Add(controller.CreateMinimapMiniature((vehicles)i, false));
                vehiclesIAs.Add(iaCar);
                totalIaCars++;
            }
        }

        StartCoroutine(CountDown());
    }

    private int CurrentPlayerPosition()
    {
        float distanceToEnd = Vector3.Distance(player.transform.position, endPosition.position);
        int position = 1;
        foreach(GameObject iaCar in vehiclesIAs)
        {
            if (iaCar != null) {
                float distanceToEndIA = Vector3.Distance(iaCar.transform.position, endPosition.position);
                if(distanceToEndIA > distanceToEnd)
                {
                    position++;
                }
            }
        }
        return position;
    }

    private  void AssignMiniaturesPosition()
    {

        Vector3 playerPosition = new Vector3(0,0,player.transform.position.z);
        playerMiniature.SetPosition(Vector3.Distance(actualStartingPosition, playerPosition));

        for(int i = 0; i < vehiclesIAs.Count; i++)
        {
            if (vehiclesIAs[i] != null)
            {
                Vector3 aiPosition = new Vector3(0, 0, vehiclesIAs[i].transform.position.z);
                aiMiniatures[i].SetPosition(Vector3.Distance(actualStartingPosition, aiPosition));
            }
            else
            {
                if(aiMiniatures[i] != null)
                    Destroy(aiMiniatures[i].gameObject);
            }
        }
    }

    public void OnExitGameButtonCliked()
    {
        SceneManager.LoadScene("GameOver");
    }

    private void StartRace()
    {
        player.GetComponent<CarMovement>().enabled = true;

        foreach(GameObject carIA in vehiclesIAs)
        {
            carIA.GetComponent<CarMovement>().enabled = true;
        }
    }


    private IEnumerator CountDown()
    {
        if (countDown > 0)
        {
            textCountDown.text = countDown.ToString();

        }else if (countDown == 0)
        {
            textCountDown.text = "Brake Down!";
            guiManager.HideControlsText();
            
        }
        else if(countDown == -1)
        {
            StartRace();
        }
        yield return new WaitForSeconds(1.0f);
        countDown--;
        if (countDown >= -1 )
        {
            StartCoroutine(CountDown());
            if(countDown == -1)
            {
                textCountDown.text = "";
            }
        }
        
    }
}
