using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{

    [SerializeField]
    private Camera carCamera;

    [SerializeField]
    private float horSpeed;
    [SerializeField]
    private float vertSpeed;
    [SerializeField]
    private float speedRotation = 3.0f;

    private Rigidbody rb;
    private Vector3 target;
    private float xOffset;
    private Vector3 direction;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        target = transform.position;
        xOffset = 0;
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

        xOffset = target.x - transform.position.x;

        direction = new Vector3(target.x,0,0) - transform.position;
        direction.Normalize();

        DrawDirection();
    }

    private void moveCharacter()
    {
        Vector3 dirToMove = new Vector3(Mathf.Clamp(xOffset,-4,4), 0,-1);
        Vector3 vel = new Vector3(dirToMove.x * horSpeed, 0, dirToMove.z * vertSpeed);

        rb.MovePosition(transform.position + (vel * Time.deltaTime));

        transform.LookAt(transform.position + new Vector3(Mathf.Clamp(xOffset, -1.5f, 1.5f), 0, transform.forward.z * 4) * speedRotation * Time.deltaTime);
        
    }

    private void DrawDirection()
    {
        Debug.DrawLine(transform.position, transform.position + new Vector3(Mathf.Clamp(xOffset, -1, 1), 0 , transform.forward.z * 4), Color.red);
    }
}
