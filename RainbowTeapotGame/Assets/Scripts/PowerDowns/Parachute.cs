using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parachute : MonoBehaviour
{
    public CarMovement car { get; set; }
    [SerializeField]
    private float speedMultiplier;
    [SerializeField]
    private float timeOfUse = 1.2f;

    private IEnumerator destroyParachuteCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        destroyParachuteCoroutine = destroyParachute();
        car.SetSpeedMultiplier(car.GetSpeedMultiplier() * speedMultiplier);
        StartCoroutine(destroyParachuteCoroutine);
    }

    private IEnumerator destroyParachute()
    {
        yield return new WaitForSeconds(timeOfUse);
        car.SetSpeedMultiplier(1.0f);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
