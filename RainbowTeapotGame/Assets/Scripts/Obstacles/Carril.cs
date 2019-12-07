using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carril : MonoBehaviour
{
    [SerializeField]
    private GameObject breakablePrefab;

    private GameObject breakable;
    private IEnumerator regenerateBreakable;

    private bool isRegenerating = false;

    // Start is called before the first frame update
    void Start()
    {
        regenerateBreakable = RegenerateBreakable();
        //CreateBreakable();
    }

    // Update is called once per frame
    void Update()
    {
        if(breakable == null && !isRegenerating)
        {
            
            StartCoroutine("RegenerateBreakable");
        }
    }

    private void CreateBreakable()
    {
        breakable = Instantiate(breakablePrefab, transform.position + Vector3.up, Quaternion.identity);
        breakable.transform.parent = transform;
        isRegenerating = false;
    }

    IEnumerator RegenerateBreakable()
    {
        isRegenerating = true;
        Debug.Log("voy a regenar el bloque");
        yield return new WaitForSeconds(1.0f);
        CreateBreakable();
    }
}
