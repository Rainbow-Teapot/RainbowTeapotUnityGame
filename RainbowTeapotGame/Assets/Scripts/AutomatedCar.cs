using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomatedCar : MonoBehaviour
{

    private Rigidbody rb;
    [SerializeField]
    private float horSpeed = 10;

    public float speedMultiplier = 1.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + new Vector3(0,0,-1) * horSpeed * speedMultiplier * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
