using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightGame : MonoBehaviour
{
    [SerializeField] private Material lightsOnMaterial;
    [SerializeField] private Material lightsOffMaterial;

    [SerializeField] bool lightOnAtStart = false;
    [SerializeField] private Light lightComp;

    [SerializeField] private LightGame leftLight;
    [SerializeField] private LightGame rightLight;

    [SerializeField] AllLightsGame allLightsGame;
    private bool lightOn;

    public void StartGame()
    {
        lightOn = lightOnAtStart;

        if (lightOn)
        {
            TurnOnLight();
        }
        else if (!lightOn)
        {
            TurnOffLight();
        }
    }

    public bool GetLightOn()
    {
        return lightOn;
    }

    public void ButtonLightPressed()
    {
        ToggleLight();
        leftLight.ToggleLight();
        rightLight.ToggleLight();

        allLightsGame.CheckVictoryGame();
    }

    public void ToggleLight()
    {
        lightOn = !lightOn;

        if (lightOn)
        {
            TurnOnLight();
        }
        else if (!lightOn)
        {
            TurnOffLight();
        }
    }

    private void TurnOnLight()
    {
        GetComponent<Renderer>().material = lightsOnMaterial;
        lightComp.enabled = lightOn;
    }

    private void TurnOffLight()
    {
        GetComponent<Renderer>().material = lightsOffMaterial;
        lightComp.enabled = lightOn;
    }


}
