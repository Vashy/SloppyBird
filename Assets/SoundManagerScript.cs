using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public enum SoundType
{
    Death,
    Score,
}

public class SoundManagerScript : MonoBehaviour
{

    private AudioSource scoreAudioSource;
    private AudioSource deadAudioSource;

    void Start()
    {
        var audioSources = GetComponents<AudioSource>();

        scoreAudioSource = audioSources[0];
        deadAudioSource = audioSources[1];
    }

    public void PlaySound(SoundType soundType)
    {
        if (soundType == SoundType.Score)
        {
            scoreAudioSource.Play();
        }
        else if (soundType == SoundType.Death)
        {
            deadAudioSource.Play();
        }
    }
}
