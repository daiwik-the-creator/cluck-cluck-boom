using UnityEngine.Audio;
using UnityEngine;
using System;

[Serializable]
public class Sound
{
    public String name;
    public AudioClip clip;

    [Range(0,5f)]
    public float volume;
    [Range (0,3)]
    public float pitch;
    public bool isLooped;

    [HideInInspector]
    public AudioSource source;
}

//heavily inspired from - Brackys unity audio tutorial, https://www.youtube.com/watch?v=6OT43pvUyfY
