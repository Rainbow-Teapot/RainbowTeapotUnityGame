using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinGamblingEfect : MonoBehaviour
{
    [SerializeField]
    private float speed = 4f;

    private Material material;
    [SerializeField]
    private bool isScrolling = false;
    private float timeScrolling = 1.0f;

    private CanvasRenderer canvas;

    private readonly float[] powerDownOffsetAtTex = new float[5] {0.8f,0.2f, 0.0f, 0.6f,0.4f};

    private float powerPickedOffset;

    [SerializeField]
    private ControllerGUI controller;

    private Image image;

    private void Awake()
    {
        canvas = GetComponent<CanvasRenderer>();
        image = GetComponent<Image>();
    }

    // Start is called before the first frame update
    void Start()
    {
        ClearImage();
    }

    public void GamblingEffect(powerDown power)
    {
        
        image.color = new Color(1, 1, 1, 1);
        isScrolling = true;
        StartCoroutine("StopGambling");
        powerPickedOffset = powerDownOffsetAtTex[(int)power];
    }

    private IEnumerator StopGambling()
    {
        yield return new WaitForSeconds(timeScrolling);
        isScrolling = false;
        Material material = canvas.GetMaterial(0);
        if (material != null)
            material.SetTextureOffset("_MainTex", new Vector2(0, powerPickedOffset));
        controller.FinishGambling();
    }

    public void ClearImage()
    {

        image.color = new Color(0, 0, 0, 0);

    }

    private void Update()
    {
        if (isScrolling)
        {
            float offset = Time.time * speed;
            Material material = canvas.GetMaterial(0);
            if(material != null)
                material.SetTextureOffset("_MainTex", new Vector2(0, offset));
           
        }
    }
}
