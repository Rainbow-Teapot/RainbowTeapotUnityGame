﻿using System.Collections;
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
    [SerializeField]
    private float brakingMultiplier = 0.1f;

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
    private AnimationCurve successHitAnotherCar;
    [SerializeField]
    private AnimationCurve failHitAnotherCar;

    private float limitBoostTransition = 0.5f;

    private Animator anim;

    private IMovement movement;
    public float xOffset;

    public enum carStates { IDLE, BOOST, HIT};
    private carStates currentState;
    private float hitDistance = -1;

    private bool hitOtherCar = false;

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

        rb.velocity = Vector3.zero;

        xOffset = movement.GetXOffset();
        
        Vector3 dirToMove = new Vector3(Mathf.Clamp(xOffset, -4, 4), 0, -1);
        //dirToMove.Normalize();
        Vector3 vel = new Vector3(dirToMove.x * horSpeed, 0, dirToMove.z * vertSpeed * speedMultiplier + currentRecoil * -0.1f);

        //transform.LookAt(transform.position + forwardDirection * speedRotation * Time.deltaTime);

        rb.MovePosition(transform.position + (vel * Time.deltaTime));
        rb.MoveRotation(Quaternion.LookRotation(forwardDirection.normalized,Vector3.up));
    }

    void Update()
    {
        //isColliding = false;
        forwardDirection = new Vector3(Mathf.Clamp(xOffset, -1.5f, 1.5f), 0, -Vector3.forward.z * forwardMultiplier);
        //forwardDirection.Normalize();
        DrawDirection();
        //Recoil();

        CarBehaviour();
        
    }

    private void CarBehaviour()
    {
        switch (currentState)
        {
            case carStates.IDLE:
                if(speedMultiplier > 1.0f)
                {
                    approach(speedMultiplier,brakingMultiplier,1.0f);
                }
                //Recoil();
                break;
            case carStates.BOOST:
                Boost();
                break;
            case carStates.HIT:
                Hit();
                break;
            default:
                Debug.LogError("Impossible Car State");
                break;
        }
    }

    private void Recoil()
    {

        if (IsCarInFront(out hitDistance))
        {
            currentRecoil += Time.deltaTime * recoilSumMultiplier;
            //Debug.Log("Aumentando el RECOIL");
        }
        else
        {
            currentRecoil -= Time.deltaTime * recoilSumMultiplier;
        }

        currentRecoil = Mathf.Clamp(currentRecoil, MIN_RECOIL, MAX_RECOIL);
        //DrawRecoilDirection();

        if (currentRecoil == MAX_RECOIL)
        {
            currentState = carStates.BOOST;
            anim.SetBool("isBoosting", true);
        }

    }


    public void Boost() {

        sumBoostTransition += Time.deltaTime;
       
        if (sumBoostTransition <= limitBoostTransition)
        {
            currentState = carStates.BOOST;

            if (hitOtherCar)
            {
                speedMultiplier = 0.5f;
               
            }
            else
            {
                speedMultiplier = failHitAnotherCar.Evaluate(sumBoostTransition);
            }
        }
        else
        {
            hitOtherCar = false;
            sumBoostTransition = 0.0f;
            currentRecoil = 0.0f;
            speedMultiplier = 1.0f;            
            currentState = carStates.IDLE;
            anim.SetBool("isBoosting", false);
        }

    }

    private void Hit()
    {
        if(speedMultiplier > 1.0f)
        {
            speedMultiplier -= Time.deltaTime * 6;
        }
        else{
            speedMultiplier = 1.0f;
            currentState = carStates.IDLE;
        }
    }

    private bool IsCarInFront(out float distance)
    {
        RaycastHit hit;
        distance = -1;

        Ray ray = new Ray(transform.position + transform.forward * 1.7f, transform.forward);
        if (Physics.Raycast(ray, out hit, recoilDistance))
        {
            distance = hit.distance;
            return hit.collider.tag == "Car";
           
        }
        
        return false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Car" && collision.collider.transform.position.z < transform.position.z
            && currentState == carStates.BOOST)
        {
            hitOtherCar = true;
            Debug.Log("He chocado con: " +  collision.collider.name);
            CarMovement car = collision.transform.GetComponent<CarMovement>();
            car.transform.rotation = Quaternion.Euler(0, 180, 0);
            car.speedMultiplier = 3.0f;
            car.currentState = carStates.HIT;
            speedMultiplier = 1.0f;
            
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        IObstacle obstacle = other.GetComponent<IObstacle>();

        if(obstacle != null)
        {
            Debug.Log("Colisionando con el obstáculo: " + other.name);
            obstacle.ApplyEffect(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IObstacle obstacle = other.GetComponent<IObstacle>();

        if (obstacle != null)
        {
            obstacle.DeApplyEffect(this);
        }
    }


    public void SetSpeedMultiplier(float speedMultiplier)
    {
        this.speedMultiplier = speedMultiplier;
    }

    private void DrawDirection()
    {
        Debug.DrawLine(transform.position, transform.position + forwardDirection, Color.red);
    }

    private void DrawRecoilDirection()
    {
        Debug.DrawLine(transform.position, transform.position + transform.forward * recoilDistance, Color.green);
    }

    private float approach(float current, float approach, float final)
    {
        if (current < final)
        {
            return Mathf.Min(current + approach,final);
        }
        else if(current > final)
        {
            return Mathf.Max(current - approach, final);
        }
        else
        {
            return final;
        }
    }

}
