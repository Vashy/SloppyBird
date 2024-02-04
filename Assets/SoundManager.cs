using UnityEngine;

public enum SoundType
{
    Death,
    Score,
}

public class SoundManager : MonoBehaviour
{
    public EventManager eventManager;

    private AudioSource scoreAudioSource;
    private AudioSource deadAudioSource;

    void Start()
    {
        var audioSources = GetComponents<AudioSource>();
        scoreAudioSource = audioSources[0];
        deadAudioSource = audioSources[1];
        eventManager.birdDeadEvent.AddListener(HandleBirdDeadEvent);
        eventManager.scoreUpEvent.AddListener(HandleScoreUpEvent);
    }

    public void PlaySound(SoundType soundType)
    {
        if (soundType == SoundType.Score)
        {
            scoreAudioSource.time = 0.15f;
            scoreAudioSource.Play();
        }
        else if (soundType == SoundType.Death)
        {
            deadAudioSource.time = 0.3f;
            deadAudioSource.Play();
        }
    }

    private void HandleBirdDeadEvent()
    {
        PlaySound(SoundType.Death);
    }

    private void HandleScoreUpEvent()
    {
        PlaySound(SoundType.Score);
    }
}
