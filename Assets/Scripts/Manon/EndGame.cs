using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] OpenOffice openOffice;
    [SerializeField] LightsOnOff lightsOnOff;
    [SerializeField] Drawer doorTV;
    [SerializeField] Drawer doorOffices;


    public void OnGameLightsEnd()
    {
        openOffice.ToggleOffice(); // Ouvre office

        // Close doors :
        doorTV.ToggleDrawer();
        doorOffices.ToggleDrawer();

        // mettres TOUTES les lights en flicker
        lightsOnOff.StartFlickerLights();

    }
}
