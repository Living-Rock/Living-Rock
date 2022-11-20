using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    void Start()
    {
        AudioSource[] audio_sources = gameObject.GetComponentsInChildren<AudioSource>();
        foreach (AudioSource source in audio_sources)
        {
            source.volume = PlayerPrefs.GetFloat("EffectsVolume");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
