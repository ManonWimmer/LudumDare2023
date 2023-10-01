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

    // MORSE
    [SerializeField] private string morseCode = "SOS";

    [SerializeField] private float timeMultiplier;

    private Dictionary<char, string> morseLetters = new Dictionary<char, string>();
    // ----- VARIABLES ----- //

    private void Start()
    {
        //StartCoroutine(FlickeringLights());
        InitializeMorseDico();
        StartCoroutine(MorseCode());
    }
    
    /*
    Morse : 
    - dico, ex : 'A' => ".-"
    dot . => 1 * timeMultiplier light on 
    dash - => 3 * timeMultiplier light on
    between each . or - => 1*timeMultiplier light off
    between full letter => 3*timeMultiplier light off
    between complete word => 7*timeMultiplier lig
     */

    private void InitializeMorseDico()
    {
        morseLetters.Add('A', ".-");
        morseLetters.Add('B', "-...");
        morseLetters.Add('C', "-.-.");
        morseLetters.Add('D', "-..");
        morseLetters.Add('E', ".");
        morseLetters.Add('F', "..-.");
        morseLetters.Add('G', "--.");
        morseLetters.Add('H', "....");
        morseLetters.Add('I', "..");
        morseLetters.Add('J', ".---");
        morseLetters.Add('K', "-.-");
        morseLetters.Add('L', ".-..");
        morseLetters.Add('M', "--");
        morseLetters.Add('N', "-.");
        morseLetters.Add('O', "---");
        morseLetters.Add('P', ".--.");
        morseLetters.Add('Q', "--.-");
        morseLetters.Add('R', ".-.");
        morseLetters.Add('S', "...");
        morseLetters.Add('T', "-");
        morseLetters.Add('U', "..-");
        morseLetters.Add('V', "...-");
        morseLetters.Add('W', ".--");
        morseLetters.Add('X', "-..-");
        morseLetters.Add('Y', "-.--");
        morseLetters.Add('Z', "--..");
    }

    private IEnumerator MorseCode()
    {
        for (int i = 0; i < morseCode.Length; i++)
        {
            string letterMorse;
            if (!morseLetters.TryGetValue(morseCode[i], out letterMorse))
            {
                Debug.Log("erreur lettre morse : " + morseCode[i]);
            }
            else
            {
                for (int j = 0; j < letterMorse.Length; j++)
                {
                    if (letterMorse[j] == '.')
                    {
                        // 1 Ligth on
                        yield return StartCoroutine(TurnOnLights(1 * timeMultiplier));
                    }
                    else if (letterMorse[j] == '-')
                    {
                        // 3 light on
                        yield return StartCoroutine(TurnOnLights(3 * timeMultiplier));
                    }
                    // 1 light off
                    yield return StartCoroutine(TurnOffLights(1 * timeMultiplier));
                }
                // 3 light off
                yield return StartCoroutine(TurnOffLights(3 * timeMultiplier));
            }
        }
        // 7 light off
        yield return StartCoroutine(TurnOffLights(7 * timeMultiplier));
        StartCoroutine(MorseCode());
    }

    private IEnumerator TurnOnLights(float time)
    {
        lightsOn = true;

        for (int i = 0; i < allLightsDefaultOn.Count; i++)
        {
            Material currentMaterial = allLightsDefaultOn[i].GetComponent<Renderer>().material;

            allLightsDefaultOn[i].GetComponent<Renderer>().material = lightsOnMaterial;
            
            // Turn light on / off :
            allLightsDefaultOn[i].GetComponentInChildren<Light>().enabled = lightsOn;
        }
        // Reflet vert :
        refletVert.GetComponent<Light>().enabled = lightsOn;

        lightsOn = !lightsOn;

        yield return new WaitForSeconds(time);
    }

    private IEnumerator TurnOffLights(float time)
    {
        lightsOn = false;

        for (int i = 0; i < allLightsDefaultOn.Count; i++)
        {
            Material currentMaterial = allLightsDefaultOn[i].GetComponent<Renderer>().material;

            allLightsDefaultOn[i].GetComponent<Renderer>().material = lightsOffMaterial;

            // Turn light on / off :
            allLightsDefaultOn[i].GetComponentInChildren<Light>().enabled = lightsOn;
        }
        // Reflet vert :
        refletVert.GetComponent<Light>().enabled = lightsOn;

        lightsOn = !lightsOn;

        yield return new WaitForSeconds(time);
    }


    // Clignoter lights pendant un count de fois (tester les lights)
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
}
