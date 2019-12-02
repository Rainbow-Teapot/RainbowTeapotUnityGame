using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidePropsSpawner : MonoBehaviour
{

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

    [SerializeField]
    private float probabilityPrioryObject = 80.0f;

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
       
    }

    public void CreateSideProps(int numProps)
    {
        int propToCreate;
        if (prioritySupport)
        {
            float priotityObject = Random.Range(0.0f, 100.0f);

            if (priotityObject > probabilityPrioryObject)
            {
                numProps = 1;
                propToCreate = Random.Range(1, propsPrefab.Length);
            }
            else
            {
                propToCreate = 0;
            }
        }
        else
        {
            propToCreate = Random.Range(0, propsPrefab.Length);
        }

        for (int i = 0; i < numProps; i++)
        {
            xAxis = Random.Range(transform.position.x - width, transform.position.x + width);
            zAxis = Random.Range(transform.position.z - height, transform.position.z);
           
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
