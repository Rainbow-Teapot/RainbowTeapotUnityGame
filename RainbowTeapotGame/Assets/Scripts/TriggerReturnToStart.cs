using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerReturnToStart : MonoBehaviour
{
    [SerializeField]
    private Transform posToStart;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("El coche ha sido puesto al principio");
        other.transform.position = new Vector3(other.transform.position.x, posToStart.position.y, posToStart.position.z);   
    }
}
