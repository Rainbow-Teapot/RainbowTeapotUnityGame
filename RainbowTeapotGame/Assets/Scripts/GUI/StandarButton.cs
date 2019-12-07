using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StandarButton : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private Image image;

    private void Start()
    {
        //image.alphaHitTestMinimumThreshold = 0.5f;
    }

    public void MouseOver()
    {
        anim.SetBool("Selected",true);
        transform.SetAsLastSibling();
    }

    public void MouseExit()
    {
        anim.SetBool("Selected", false);
    }

    public void MouseDown()
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        if(audioManager)    audioManager.Play("Button");
        anim.SetBool("Pressed", true);
        anim.SetBool("Released", false);
        transform.SetAsLastSibling();
    }

    public void MouseUp()
    {
        anim.SetBool("Released", true);
        anim.SetBool("Selected", false);
        anim.SetBool("Pressed", false);
    }
}
