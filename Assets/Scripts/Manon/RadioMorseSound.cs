using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioMorseSound : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] LightsOnOff lightsOnOff;


    private void Update()
    {
        //Debug.Log(audioSource.isPlaying + " " + lightsOnOff.IsMorseRunning + " " + lightsOnOff.LightsOn);
        if (!audioSource.isPlaying && lightsOnOff.IsMorseRunning && lightsOnOff.LightsOn)
        {
            audioSource.Play();
        }
        else if (!lightsOnOff.LightsOn)
        {
            audioSource.Stop();
        }

    }
}
