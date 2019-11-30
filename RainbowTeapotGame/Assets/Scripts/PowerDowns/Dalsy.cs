﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dalsy : MonoBehaviour
{

    [SerializeField]
    private float speedMultiplier;

    [SerializeField]
    private float timeOfUse = 2.0f;

    private SpeedMultiplierDecorator dalsyDecorator;
    private IEnumerator finishEffectCoroutine;

    public CarMovement car;

    

    // Start is called before the first frame update
    void Start()
    {
        dalsyDecorator = new SpeedMultiplierDecorator(speedMultiplier);
        finishEffectCoroutine = FinishEffect();

        car.AddSpeedDecorator(dalsyDecorator);
        car.SetCurrentCarState(carStates.ZIGZAG);

        StartCoroutine(finishEffectCoroutine);
        car.GetComponent<ChangeMaterialColors>().ChangeColor(Color.red);
        
       
    }

    private IEnumerator FinishEffect()
    {
        Debug.Log("HE ACTIVADO EL DALSY");
        yield return new WaitForSeconds(timeOfUse);
        Debug.Log("EL SALDY SE ACABA");
        car.RemoveSpeedDecorator(dalsyDecorator);
        car.GetComponent<ChangeMaterialColors>().ResetColor();
        car.SetCurrentCarState(carStates.IDLE);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
