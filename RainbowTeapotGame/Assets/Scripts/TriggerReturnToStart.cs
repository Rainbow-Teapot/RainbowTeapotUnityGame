using Photon.Pun.Demo.Asteroids;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerReturnToStart : MonoBehaviour
{
    [SerializeField]
    private Transform posToStart;
    private PlayerInfo playerInfo;

    [SerializeField]
    private MultiplayerGameManager manager;

    private void Start()
    {
        playerInfo = GameObject.Find("PlayerInfo").GetComponent<PlayerInfo>();
        if(playerInfo != null)
        {
            Debug.Log("HAY información del player");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("El coche ha sido puesto al principio");
        if (playerInfo != null)
        {
            Debug.Log("ME DESCONECTO");
            manager.EndOfRace();

        }
        else
        {
            other.transform.position = new Vector3(other.transform.position.x, posToStart.position.y, posToStart.position.z);
        }
    }
}
