using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurboBackNetwork : MonoBehaviourPun, IPunInstantiateMagicCallback, IObstacle
{
    private TurboBack turboBack;

    private PhotonView pv;

    private IEnumerator destroyTurboBackCoroutine;

    private GameObject carOwner;

    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        int player = (int)info.photonView.InstantiationData[0];
        Debug.Log("He instaniciado el TURBOBACK: " + "EmulatedCar" + player);

        GameObject carObject = GameObject.Find("EmulatedCar" + player);
        if (carObject)
        {

            Debug.Log("Colocado eprfecto");
            //transform.parent = carObject.transform;
            turboBack.ownerCar = carObject.GetComponent<CarMovement>();
            carOwner = carObject;

        }
    }

    private void Awake()
    {
        turboBack = GetComponent<TurboBack>();
        pv = GetComponent<PhotonView>();
    }



    // Start is called before the first frame update
    void Start()
    {
        if (pv.IsMine)
        {
            turboBack.enabled = true;
            
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ApplyEffect(CarMovement car)
    {
        turboBack.ApplyEffect(car);
    }

    public void DeApplyEffect(CarMovement car)
    {
        //throw new System.NotImplementedException();
    }
}
