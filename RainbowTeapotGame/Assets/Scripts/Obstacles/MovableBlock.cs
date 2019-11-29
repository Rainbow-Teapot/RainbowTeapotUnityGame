using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableBlock : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;

    private int faceX = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * faceX * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        faceX = -faceX;
    }
}
