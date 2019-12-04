using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownText : MonoBehaviour
{
    private Text textObject;
    private string text = "";
    private string lastText = "";
    [SerializeField]
    private float reduceSizeSpeed;
    [SerializeField]
    private int maxFontSize;

    private void Awake()
    {
        textObject = GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text = textObject.text;
        if (text.Equals(lastText))
        {
            textObject.fontSize -= (int)(reduceSizeSpeed * Time.deltaTime);
            Debug.Log("CAMBIANDO LA FUENTE: " + textObject.fontSize);
        }
        /*else
        {
            textObject.fontSize = maxFontSize;
            lastText = text.ToString();
        }*/
    }
}
