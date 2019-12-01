using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurboBack : MonoBehaviour, IObstacle
{

    private CarMovement car;

    public CarMovement ownerCar;

    [SerializeField]
    private float speedMultiplier = 1.7f;
    [SerializeField]
    private float timeOfTakeOff = 1.2f;
    [SerializeField]
    private float timeOfUse = 1.2f;

    [SerializeField]
    private float speed;

    private bool hasCollide = false;

    private IEnumerator destroyTurboDontHitCoroutine;
    private IEnumerator destroyTurboHitCoroutine;

    private SpeedMultiplierDecorator turboDecorator;

    private void Start()
    {
        turboDecorator = new SpeedMultiplierDecorator(speedMultiplier);
        destroyTurboDontHitCoroutine = DestroyTurboDontHit();
        destroyTurboHitCoroutine = DestroyTurboHit();
        StartCoroutine(destroyTurboDontHitCoroutine);
    }

    private void Update()
    {
        if(!hasCollide)
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void ApplyEffect(CarMovement car)
    {
        if (enabled)
        {
            if (!hasCollide && ownerCar != car)
            {
                this.car = car;
                hasCollide = true;
                transform.parent = car.transform;
                transform.localPosition = new Vector3(0, 2, -1);
                //transform.localRotation = Quaternion.Euler(0, 180, 0);
                transform.Rotate(new Vector3(0, 180, 0));
                car.AddSpeedDecorator(turboDecorator);
                StartCoroutine(destroyTurboHitCoroutine);
            }
        }
    }

    public void DeApplyEffect(CarMovement car)
    {
        
    }

    private IEnumerator DestroyTurboDontHit()
    {
        yield return new WaitForSeconds(timeOfTakeOff);
        if (!hasCollide)
        {
            Destroy(gameObject);
        }
    }
    private IEnumerator DestroyTurboHit()
    {
        yield return new WaitForSeconds(timeOfUse);
        car.RemoveSpeedDecorator(turboDecorator);
        Destroy(gameObject);
    }
}
