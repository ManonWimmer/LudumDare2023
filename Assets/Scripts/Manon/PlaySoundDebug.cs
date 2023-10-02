using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundDebug : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] bool playAtStart = true;

    private void Start()
    {
        if (playAtStart)
        {
            audioSource.Play();
        }
    }
}
