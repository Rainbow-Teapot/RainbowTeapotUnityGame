using Photon.Pun.Demo.Asteroids;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerReturnToStart : MonoBehaviour
{
    [SerializeField]
    private Transform posToStart;
    private PlayerInfo playerInfo;

    [SerializeField]
    private MultiplayerGameManager manager;
    private bool isDebug = false;

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
        if(isDebug)
        {
            other.transform.position = new Vector3(other.transform.position.x, posToStart.position.y, posToStart.position.z);
        }
        else if (playerInfo != null && manager != null)
        {
            Debug.Log("ME DESCONECTO");
            manager.EndOfRace();

        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
