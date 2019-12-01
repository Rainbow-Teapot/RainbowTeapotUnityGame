using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Teapot : MonoBehaviour
{
    [SerializeField]
    private GameObject TeaPuddlePrefab;

    private PhotonView pv;

    private void Awake()
    {
        pv = GetComponent<PhotonView>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Floor"))
        {
            CreateTeaPuddle();
            Destroy(gameObject);
            if (pv != null && pv.IsMine)
            {
                PhotonNetwork.Destroy(gameObject);
            }
        }
    }

    private void CreateTeaPuddle()
    {
        Vector3 posToSpawn = transform.position + Vector3.up * 0.25f;

        if (pv == null)
        {
            Instantiate(TeaPuddlePrefab, posToSpawn, Quaternion.identity);
        }
        else
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "TeaPuddleNetwork"), posToSpawn, Quaternion.identity, 0);
        }
    }
}
