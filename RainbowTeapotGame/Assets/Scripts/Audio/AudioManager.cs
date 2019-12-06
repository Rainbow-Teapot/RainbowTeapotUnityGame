using UnityEngine.Audio;
using System;
using UnityEngine;

using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    

    private void Awake()
    {

       // DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name.Contains("Level1"))
        {

            Play("Countdown1");
        }
        if (SceneManager.GetActiveScene().name.Contains("Level2"))
        {

            Play("Countdown2");
        }
        if (SceneManager.GetActiveScene().name.Contains("Level3"))
        {

            Play("Countdown3");
        }

    }

    public void Play(string name) {
        Sound s =  Array.Find(sounds, sound => sound.name == name);
        if (s == null) {
            Debug.LogWarning("Sound " +name+ " not found!");
            return; 
        }
        if(FindObjectOfType<PlayerInfo>().soundsOn)
            s.source.Play();
    }

    public void Character(string name) {
        switch (name) {
            //Carrito, Naranjita, Patin, Vaca, Vater,Telefono
            case "Carrito":
                Play("Cart1");
            break;
            case "Naranjita":
                Play("Orange1");
                break;
            case "Patin":
                Play("Skate1");
                break;
            case "Vaca":
                Play("Cow1");
                break;
            case "Vater":
                Play("Toilet1");
                break;
            case "Telefono":
                Play("Phone1");
                break;        

        }

    }

}
