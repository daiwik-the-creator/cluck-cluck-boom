using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            //s.source.loop = s.isLooped;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    private void Start()
    {
        PlaySound("Theme");
    }
    public void PlaySound(string sName)
    {
        Debug.Log("trying to play" + sName);
        Sound s = Array.Find(sounds, sound => sound.name == sName);
        if (s == null)
        {
            Debug.Log("ERROR: Name not found");
            return;
        }
            
        s.source.Play();
        
    }

}
//heavily inspired from - Brackys unity audio tutorial, https://www.youtube.com/watch?v=6OT43pvUyfY