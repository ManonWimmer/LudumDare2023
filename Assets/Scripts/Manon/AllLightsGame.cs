using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllLightsGame : MonoBehaviour
{
    [SerializeField] private List<LightGame> gameLights= new List<LightGame>();

    public void InitializeLightsGame()
    {
        Debug.Log("init ligts game");
        for (int i = 0; i < gameLights.Count; i++)
        {
            gameLights[i].StartGame();
        }
    }
}
