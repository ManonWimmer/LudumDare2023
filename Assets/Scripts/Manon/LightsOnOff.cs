using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class LightsOnOff : MonoBehaviour
{
    // ----- VARIABLES ----- //
    [SerializeField] private Material lightsOnMaterial;
    [SerializeField] private Material lightsOffMaterial;

    [SerializeField] private GameObject refletVert;

    [SerializeField] private List<GameObject> allLightsDefaultOn = new List<GameObject>();

    [SerializeField] private bool lightsOn = false;

    private float count = 0; // temp
    // ----- VARIABLES ----- //

    private void Start()
    {
        StartCoroutine(FlickeringLights());
    }

    private IEnumerator FlickeringLights()
    {
        for(int i = 0; i < allLightsDefaultOn.Count; i++)
        {
            Material currentMaterial = allLightsDefaultOn[i].GetComponent<Renderer>().material;

            // Change material on / off :
            if (!lightsOn)
            {
                allLightsDefaultOn[i].GetComponent<Renderer>().material = lightsOffMaterial;
            }
            else if (lightsOn)
            {
                allLightsDefaultOn[i].GetComponent<Renderer>().material = lightsOnMaterial;
            }


            // Turn light on / off :
            allLightsDefaultOn[i].GetComponentInChildren<Light>().enabled = lightsOn;
        }
        // Reflet vert :
        refletVert.GetComponent<Light>().enabled = lightsOn;
        
        lightsOn = !lightsOn;

        count++;

        yield return new WaitForSeconds(1f);

        if (count < 40)
        {
            StartCoroutine(FlickeringLights());
        }
        
    }

    //gameObject.renderer.material = material1;
}
