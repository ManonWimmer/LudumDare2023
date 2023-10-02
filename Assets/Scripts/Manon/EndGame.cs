using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] OpenOffice openOffice;
    [SerializeField] LightsOnOff lightsOnOff;
    [SerializeField] Drawer doorTV;
    [SerializeField] Drawer doorOffices;
    [SerializeField] AudioSource playerAudioSource;
    [SerializeField] AudioClip alarmSound;

    public void OnGameLightsEnd()
    {
        openOffice.ToggleOffice(); // Ouvre office

        // Close doors :
        doorTV.ToggleDrawer();
        doorOffices.ToggleDrawer();

        // ALARM 
        playerAudioSource.clip = alarmSound;
        playerAudioSource.Play();


        // mettres TOUTES les lights en flicker
        lightsOnOff.StartFlickerLights();

    }
}
