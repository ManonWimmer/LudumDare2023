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

    public void ButtonLightPressed()
    {
        ToggleLight();
        leftLight.ToggleLight();
        rightLight.ToggleLight();
        // check si toutes les lights allum�es
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
