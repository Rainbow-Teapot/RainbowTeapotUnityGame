using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputedMovement : MonoBehaviour, IMovement
{
    public float xOffset;
    private Vector3 target;
    [SerializeField]
    private Camera carCamera;

    // Start is called before the first frame update
    void Start()
    {
        xOffset = 0;
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetMouseButton(0))
        {
            Ray ray = carCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                target = hit.point;
            }

            xOffset = target.x - transform.position.x;
        }
        else
        {
            xOffset = 0.0f;
        }

        








    }

    public float GetXOffset()
    {
        return xOffset;
    }
}
