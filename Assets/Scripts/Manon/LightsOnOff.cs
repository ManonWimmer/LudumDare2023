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

    [SerializeField] private bool lightsOn = true;

    // MORSE
    [SerializeField] private List<String> morseCodeList = new List<String>();

    [SerializeField] private float timeMultiplier;

    private Dictionary<char, string> morseLetters = new Dictionary<char, string>();

    // FLICKER
    [SerializeField] private float flickerTime = 0.25f;
    private bool flickerLightOn;

    private bool isMorseRunning = true;

    public bool IsMorseRunning { get => isMorseRunning; private set => isMorseRunning = value; }
    public bool LightsOn { get => lightsOn; private set => lightsOn = value; }

    // ----- VARIABLES ----- //

    private void Start()
    {
        //StartCoroutine(FlickeringLights());
        InitializeMorseDico();
        isMorseRunning = true;
        StartCoroutine(MorseCode());
    }

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

    public void StopMorse()
    {
        isMorseRunning = false;
    }

    private IEnumerator MorseCode()
    {
        while (isMorseRunning)
        {
            for (int x = 0; x < morseCodeList.Count; x++)
            {
                string morseCode = morseCodeList[x]; // Chaque mot

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
                            if (letterMorse[j] == '.' && isMorseRunning)
                            {
                                // 1 Ligth on
                                yield return StartCoroutine(TurnOnLights(1 * timeMultiplier));
                            }
                            else if (letterMorse[j] == '-' && isMorseRunning)
                            {
                                // 3 light on
                                yield return StartCoroutine(TurnOnLights(3 * timeMultiplier));
                            }
                            // 1 light off
                            if (isMorseRunning)
                                yield return StartCoroutine(TurnOffLights(1 * timeMultiplier));
                        }
                        // 3 light off
                        if (isMorseRunning)
                            yield return StartCoroutine(TurnOffLights(3 * timeMultiplier));
                    }
                }
                // 7 light off
                if (isMorseRunning)
                {
                    yield return StartCoroutine(TurnOffLights(7 * timeMultiplier));
                    StartCoroutine(MorseCode());
                }
            }
        }  
    }

    private IEnumerator TurnOnLights(float time)
    {
        Debug.Log("turn on lights");
        lightsOn = true;

        for (int i = 0; i < allLightsDefaultOn.Count; i++)
        {

            //Material currentMaterial = allLightsDefaultOn[i].GetComponent<Renderer>().material;

            allLightsDefaultOn[i].GetComponent<Renderer>().material = lightsOnMaterial;
            
            // Turn light on / off :
            allLightsDefaultOn[i].GetComponentInChildren<Light>().enabled = lightsOn;
        }
        // Reflet vert :
        refletVert.GetComponent<Light>().enabled = lightsOn;

        //lightsOn = !lightsOn;

        yield return new WaitForSeconds(time);
    }

    private IEnumerator TurnOffLights(float time)
    {
        lightsOn = false;

        for (int i = 0; i < allLightsDefaultOn.Count; i++)
        {

            //Material currentMaterial = allLightsDefaultOn[i].GetComponent<Renderer>().material;

            allLightsDefaultOn[i].GetComponent<Renderer>().material = lightsOffMaterial;

            // Turn light on / off :
            allLightsDefaultOn[i].GetComponentInChildren<Light>().enabled = lightsOn;
        }
        // Reflet vert :
        refletVert.GetComponent<Light>().enabled = lightsOn;

        //lightsOn = !lightsOn;

        yield return new WaitForSeconds(time);
    }

    public void StartFlickerLights()
    {
        StartCoroutine(FlickerLights());
    }

    private IEnumerator FlickerLights()
    {
        Debug.Log(flickerLightOn);


        if (!flickerLightOn)
        {
            yield return StartCoroutine(TurnOffLights(flickerTime));
        }
        else if (flickerLightOn)
        {
            yield return StartCoroutine(TurnOnLights(flickerTime));
        }
        

        flickerLightOn = !flickerLightOn;
        yield return StartCoroutine(FlickerLights());
    }
}
