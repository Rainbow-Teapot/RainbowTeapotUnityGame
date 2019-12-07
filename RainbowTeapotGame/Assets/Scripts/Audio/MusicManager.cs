using UnityEngine.Audio;
using System;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{

    public Sound[] sounds;
    

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
            PlayOrPause("MenuTheme");
        }
        
    }

    public void PlayOrPause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found!");
            return;
        }
        if (FindObjectOfType<PlayerInfo>().musicOn)
            s.source.Play();
        else {
            s.source.Pause();
        }
    }

   
}