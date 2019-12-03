using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    [SerializeField]
    private float zOffset = 20;

    [SerializeField]
    private float yOffset = -2;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = new Vector3(transform.position.x, target.transform.position.y + yOffset, target.transform.position.z + zOffset);
        }
        
    }

    public void setTarget(GameObject target)
    {
        this.target = target;
    }
}
