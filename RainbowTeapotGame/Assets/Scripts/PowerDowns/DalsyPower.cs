using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DalsyPower : MonoBehaviour, IPowerDown
{
    [SerializeField]
    private GameObject dalsyPrefab;

    public void Activate(CarMovement car)
    {
        Debug.Log("[POWER-DOWN]: " + name);

        FindObjectOfType<AudioManager>().Play("Glup");
        Dalsy dalsy = Instantiate(dalsyPrefab, Vector3.zero, Quaternion.identity).GetComponent<Dalsy>();
        dalsy.car = car;
    }
}
