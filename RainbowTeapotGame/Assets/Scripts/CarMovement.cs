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

    [SerializeField]
    private float speedMultiplier = 1.0f;

    private Vector3 forwardDirection;
    private float forwardMultiplier = 4.0f;

    [SerializeField]
    private float recoilDistance = 6.0f;
    [SerializeField]
    private float currentRecoil = 0.0f;
    [SerializeField]
    private float recoilSumMultiplier = 1.0f;
    private float MAX_RECOIL = 4.0f;
    private float MIN_RECOIL = 0.0f;

    private float sumBoostTransition = 0.0f;
    [SerializeField]
    private AnimationCurve boostTransition;
    private float limitBoostTransition = 0.5f;

    private Animator anim;

    private IMovement movement;
    private float xOffset;

    public enum carStates { IDLE, BOOST, HIT};
    private carStates currentState;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        movement = GetComponent<IMovement>();
    }

    private void Start()
    {
        currentState = carStates.IDLE;
    }


    private void FixedUpdate()
    {
        moveCharacter();   
    }

    private void moveCharacter()
    {
        xOffset = movement.GetXOffset();
        Vector3 dirToMove = new Vector3(Mathf.Clamp(xOffset, -4, 4), 0, -1);
        Vector3 vel = new Vector3(dirToMove.x * horSpeed, 0, dirToMove.z * vertSpeed * speedMultiplier + currentRecoil * -0.1f);

        rb.MovePosition(transform.position + (vel * Time.deltaTime));

        transform.LookAt(transform.position + forwardDirection * speedRotation * Time.deltaTime);

    }

    void Update()
    {
        forwardDirection = new Vector3(Mathf.Clamp(xOffset, -1.5f, 1.5f), 0, transform.forward.z * forwardMultiplier);
        Recoil();

        CarBehaviour();

    }

    private void CarBehaviour()
    {
        switch (currentState)
        {
            case carStates.IDLE:
                Recoil();
                break;
            case carStates.BOOST:
                Boost();
                break;
            case carStates.HIT:
                break;
            default:
                Debug.LogError("Impossible Car State");
                break;
        }
    }

    private void Recoil()
    {
        if (IsCarInFront())
        {
            currentRecoil += Time.deltaTime * recoilSumMultiplier;
            //Debug.Log("Aumentando el RECOIL");
        }
        else
        {
            currentRecoil -= Time.deltaTime * recoilSumMultiplier;
        }

        currentRecoil = Mathf.Clamp(currentRecoil, MIN_RECOIL, MAX_RECOIL);
        DrawRecoilDirection();

        if (currentRecoil == MAX_RECOIL)
        {
            currentState = carStates.BOOST;
        }

    }


    private void Boost() {

        sumBoostTransition += Time.deltaTime;
       
        if (sumBoostTransition <= limitBoostTransition)
        {
            anim.SetBool("isBoosting", true);
            speedMultiplier = boostTransition.Evaluate(sumBoostTransition);
        }
        else
        {
            sumBoostTransition = 0.0f;
            currentRecoil = 0.0f;
            speedMultiplier = 1.0f;
            currentState = carStates.HIT;
            anim.SetBool("isBoosting", false);
        }

    }

    private bool IsCarInFront()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position + transform.forward * 1.7f, transform.forward);
        if (Physics.Raycast(ray, out hit, recoilDistance))
        {
            return hit.collider.tag == "Car";
           
        }

        return false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Car")
        {
            Debug.Log("He chocado");
            CarMovement car = collision.transform.GetComponent<CarMovement>();
            car.speedMultiplier = 4.0f;
            speedMultiplier = 1.0f;
        }
    }

    private void DrawDirection()
    {
        Debug.DrawLine(transform.position, transform.position + forwardDirection, Color.red);
    }

    private void DrawRecoilDirection()
    {
        Debug.DrawLine(transform.position, transform.position + transform.forward * recoilDistance, Color.green);
    }
   
}
