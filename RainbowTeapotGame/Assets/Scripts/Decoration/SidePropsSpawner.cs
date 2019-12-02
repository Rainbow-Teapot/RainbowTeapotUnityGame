using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidePropsSpawner : MonoBehaviour
{
    [SerializeField]
    private CameraController camera;

    private float speed;

    [SerializeField]
    private GameObject[] propsPrefab;

    [SerializeField]
    private int maxProps;
    [SerializeField]
    private int quantityPropGroup;

    private int currentPropsNum = 0;
    [SerializeField]
    private float width;
    [SerializeField]
    private float height;

    float xAxis;
    float zAxis;
    float yAxis;

    [SerializeField]
    private float spawnSpeed;

    [SerializeField]
    private GameObject decoration;

    [SerializeField]
    private bool prioritySupport = false;

    // Start is called before the first frame update
    void Start()
    {
        yAxis = transform.position.y;
        //CreateSideProps(maxProps);
        StartCoroutine(CreateSomeSideProps());
    }

    // Update is called once per frame
    void Update()
    {
        speed = camera.speed;
        speed = 4.0f;
        
    }

    public void CreateSideProps(int numProps)
    {
        int propToCreate = Random.Range(0, 100);

        if (propToCreate != 0)
        {
            numProps = 1;
        }

        for (int i = 0; i < numProps; i++)
        {
            xAxis = Random.Range(transform.position.x - width, transform.position.x + width);
            zAxis = Random.Range(transform.position.z - height, transform.position.z + height);
           
            GameObject prop = Instantiate(propsPrefab[propToCreate], new Vector3(xAxis, yAxis, zAxis), Quaternion.identity);
            prop.transform.parent = decoration.transform;
            //SideProp sideProp = prop.GetComponent<SideProp>();
        }
    }

    private IEnumerator CreateSomeSideProps()
    {
        yield return new WaitForSeconds(spawnSpeed);
     
        CreateSideProps(quantityPropGroup);
        StartCoroutine(CreateSomeSideProps());
    }

}
