using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackAudio : MonoBehaviour
{
    [SerializeField] AudioClip audioClip;
    [SerializeField] AudioSource audioSource;
    [Range(0, 1)][SerializeField] float volume = 1;

    public void Play()
    {
        audioSource.PlayOneShot(audioClip, volume);
    }
}
