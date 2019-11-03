using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{

    [SerializeField]
    private Camera carCamera;

    [SerializeField]
    private float speed = 10.0f;
    [SerializeField]
    private float speedRotation = 3.0f;

    private Rigidbody rb;
    private Vector3 target;
    private Vector3 direction;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        target = transform.position;
        direction = new Vector3(0,0,0);
    }

    private void FixedUpdate()
    {
        moveCharacter();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = carCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit))
            {
                target = hit.point;
            }
                
        }

        direction = new Vector3(target.x,0,0) - transform.position;
        //direction.y = 0;
        direction.Normalize();
        DrawDirection();
    }

    private void moveCharacter()
    {
        Vector3 dirToMove = new Vector3(direction.x, 0,0);
        
        rb.MovePosition(transform.position + (dirToMove * speed * Time.deltaTime));

        transform.LookAt(transform.position + new Vector3(direction.x * 2, 0, transform.forward.z * 4) * speedRotation * Time.deltaTime);
        
    }

    private void DrawDirection()
    {
        Debug.DrawLine(transform.position, transform.position + new Vector3(direction.x * 2, 0 , transform.forward.z * 4), Color.red);
    }
}
