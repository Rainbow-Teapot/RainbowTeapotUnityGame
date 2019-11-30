using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parachute : MonoBehaviour
{
    public CarMovement car { get; set; }
    [SerializeField]
    private float speedMultiplier;
    [SerializeField]
    public float timeOfUse = 1.2f;

    private IEnumerator destroyParachuteCoroutine;
    private SpeedMultiplierDecorator parachuteDecorator;

    // Start is called before the first frame update
    void Start()
    {
        parachuteDecorator = new SpeedMultiplierDecorator(speedMultiplier);
        destroyParachuteCoroutine = destroyParachute();
        car.AddSpeedDecorator(parachuteDecorator);
        StartCoroutine(destroyParachuteCoroutine);
    }

    private IEnumerator destroyParachute()
    {
        yield return new WaitForSeconds(timeOfUse);
        DestroyParachute();
    }

    public void DestroyParachute()
    {
        car.RemoveSpeedDecorator(parachuteDecorator);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
