using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToSpawnPrefab;
    public GameObject objectSpawned;

    private bool isSpawning = false;


    // Update is called once per frame
    void Update()
    {
        if (objectSpawned == null && !isSpawning)
        {
            isSpawning = true;
            StartCoroutine("SpawnObject");

        }
        
    }

    IEnumerator SpawnObject()
    {
        
        yield return new WaitForSeconds(2.0f);
        objectSpawned = Instantiate(objectToSpawnPrefab,transform.position,Quaternion.identity);
        isSpawning = false;
        
    }
}
