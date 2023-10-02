using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class AllLightsGame : MonoBehaviour
{
    [SerializeField] private List<LightGame> gameLights= new List<LightGame>();
    [SerializeField] private bool gameVictory = false; // serialize juste pour tests

    public bool GameVictory { get => gameVictory; set => gameVictory = value; }

    public void InitializeLightsGame()
    {
        Debug.Log("init ligts game");
        for (int i = 0; i < gameLights.Count; i++)
        {
            gameLights[i].StartGame();
        }
    }
    public void CheckVictoryGame()
    {
        bool tempB = true;
        for (int i = 0; i < gameLights.Count; i++)
        {
            if (!gameLights[i].GetLightOn())
            {
                //tempB = false; // Enlevé pour test
                Debug.Log("victory false");
            }
        }
        if (tempB)
        {
            Debug.Log("victory");
            gameVictory = true;
            VictoryLights();
        }
    }

    private void VictoryLights()
    {
        for (int i = 0; i < gameLights.Count; i++)
        {
            gameLights[i].TurnOnLight();
        }

        for (int i = 0; i < gameLights.Count; i++)
        {
            gameLights[i].StartFlickerLight();
        }
    }
}
