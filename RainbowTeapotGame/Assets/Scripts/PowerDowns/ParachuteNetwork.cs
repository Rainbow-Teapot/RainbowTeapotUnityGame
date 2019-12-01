using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParachuteNetwork : MonoBehaviourPun, IPunInstantiateMagicCallback
{
    private Parachute parachute;

    private PhotonView pv;

    private IEnumerator destroyParachuteCoroutine;

    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        int player = (int)info.photonView.InstantiationData[0];
        Debug.Log("He instaniciado el parachute: " + "EmulatedCar" + player);
        
        GameObject carObject = GameObject.Find("EmulatedCar" + player);
        if (carObject)
        {
           
                Debug.Log("Colocado eprfecto");
                transform.parent = carObject.transform;
                //parachute.car = car;
            
        }
    }

    private void Awake()
    {
        parachute = GetComponent<Parachute>();
        pv = GetComponent<PhotonView>();
    }

    

    // Start is called before the first frame update
    void Start()
    {
        if (pv.IsMine)
        {
            parachute.enabled = true;
            destroyParachuteCoroutine = destroyParachute();
            StartCoroutine(destroyParachuteCoroutine);
        }   
    }

    private IEnumerator destroyParachute()
    {
        yield return new WaitForSeconds(2.0f);
        parachute.DestroyParachute();
        PhotonNetwork.Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
