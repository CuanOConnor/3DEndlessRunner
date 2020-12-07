﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;

    private float musicVolume = 1f;

    void Start()
    {
        foreach(Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
        }

        PlaySound("MainTheme");
    }

    private void Update()
    {
        foreach (Sounds s in sounds)
        {
            s.source.volume = musicVolume;
        }
    }


    public void PlaySound(string name)
    {
        foreach (Sounds s in sounds)
        {
            if (s.name == name)
            {
                s.source.Play();
            }
        }
    }

    public void UpdateVolume(float volume)
    {
        musicVolume = volume;
    }
}
