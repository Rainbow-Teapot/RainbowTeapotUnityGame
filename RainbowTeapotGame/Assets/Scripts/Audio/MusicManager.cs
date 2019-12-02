using UnityEngine.Audio;
using System;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{

    public Sound[] sounds;
    public bool generalMusic = true;

    private void Awake()
    {
        // DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        
        if (SceneManager.GetActiveScene().name.Equals("Lobby"))
        {
            Play("MenuTheme");
        }

        if (SceneManager.GetActiveScene().name.Equals("MultiplayerTest"))
        {

            Play("Level1");
        }
        
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found!");
            return;
        }
        if(generalMusic)
            s.source.Play();
    }
}