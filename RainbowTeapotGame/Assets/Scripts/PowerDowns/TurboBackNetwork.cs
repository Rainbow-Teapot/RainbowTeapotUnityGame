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
            //turboBack.ownerCar = GetComponent<CarMovement>();
            //destroyParachuteCoroutine = destroyParachute();
            //StartCoroutine(destroyParachuteCoroutine);
        }
    }

    private IEnumerator destroyParachute()
    {
        yield return new WaitForSeconds(2.0f);
        //parachute.DestroyParachute();
        PhotonNetwork.Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ApplyEffect(CarMovement car)
    {
        if(car.gameObject != carOwner)
        {
            Debug.Log("JAJAJAAJAJAJ");
        }
    }

    public void DeApplyEffect(CarMovement car)
    {
        throw new System.NotImplementedException();
    }
}
