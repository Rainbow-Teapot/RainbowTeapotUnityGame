using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teapot : MonoBehaviour
{
    [SerializeField]
    private GameObject TeaPuddlePrefab;

    private void OnTriggerEnter(Collider other)
    {
        CreateTeaPuddle();
        Destroy(gameObject);
    }

    private void CreateTeaPuddle()
    {
        Instantiate(TeaPuddlePrefab, transform.position, Quaternion.identity);
    }
}
