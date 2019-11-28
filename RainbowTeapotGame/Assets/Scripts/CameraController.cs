using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float zOffset = 20;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
            transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z + zOffset);
        
    }

    public void setTarget(GameObject target)
    {
        player = target;
    }
}
