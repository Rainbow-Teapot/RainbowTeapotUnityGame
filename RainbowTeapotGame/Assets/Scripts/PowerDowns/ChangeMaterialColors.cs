using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialColors : MonoBehaviour
{
    private Color[] modelColors;

    private Renderer[] carRenderers;

    private PlayerControllerNetwork playerNetwork;

    public void ChangeColor(Color color)
    {   
        int i = 0;
        foreach (Renderer render in carRenderers)
        {
            render.material.color = color;
            i++;
        }

        if (playerNetwork)
        {
            playerNetwork.hasDalsy = true;
        }
    }

    public void ResetColor()
    {   
        int i = 0;
        foreach (Renderer render in carRenderers)
        {
            render.material.color = modelColors[i];
            i++;
        }
        if (playerNetwork)
        {
            playerNetwork.hasDalsy = false;
        }
    }

    private void Awake()
    {
        
        playerNetwork = GetComponent<PlayerControllerNetwork>();
    }

    // Start is called before the first frame update
    void Start()
    {
        carRenderers = transform.GetChild(0).GetComponentsInChildren<Renderer>();
        modelColors = new Color[carRenderers.Length];
        int i = 0;
        foreach (Renderer render in carRenderers)
        {
            
            modelColors[i] = render.material.color;
            i++;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
