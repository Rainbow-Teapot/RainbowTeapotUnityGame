﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBlock : MonoBehaviour,IObstacle
{
    [SerializeField]
    private float speedMultiplier = 0.25f;
    [SerializeField]
    private string audioclip;

    [SerializeField]
    private GameObject particlePrefab;
   // private string audioclip = "Lego";
   // private string audioclip = "Paper";
    //private string audioclip = "Bounce";

    public void ApplyEffect(CarMovement car)
    {
        if(audioclip!=null)
            FindObjectOfType<AudioManager>().Play(audioclip);
        //car.SetSpeedMultiplier(speedMultiplier);
        if (particlePrefab != null)
        {
            GameObject particle = Instantiate(particlePrefab, car.transform.position + Vector3.back * 1.5f + Vector3.up, Quaternion.identity);
            particle.transform.parent = car.transform;
        }
        car.SetVertSpeed(speedMultiplier);
        car.SetCurrentCarState(carStates.IDLE);
        Destroy(gameObject);
    }

    public void DeApplyEffect(CarMovement car)
    {
        //throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
