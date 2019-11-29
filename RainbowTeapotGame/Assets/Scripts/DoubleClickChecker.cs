using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleClickChecker : MonoBehaviour
{
    private const float DOUBLE_CLICK_TIME = 0.2f;
    private float lastClickTime;

    public bool HasBeenDoubleClick()
    {
        bool hasBeenDoubleClick = false;

        if (Input.GetMouseButtonDown(0))
        {
            float timeSinceLastClick = Time.time - lastClickTime;
            if(timeSinceLastClick <= DOUBLE_CLICK_TIME)
            {
                Debug.Log("DOUBLE CLICK!");
                hasBeenDoubleClick = true;
            }
            lastClickTime = Time.time;
        }

        return hasBeenDoubleClick;
    }
}
