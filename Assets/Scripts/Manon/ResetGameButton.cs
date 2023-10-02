using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGameButton : MonoBehaviour
{
    [SerializeField] AllLightsGame allLightsGame;

    public void ButtonPressed()
    {
        allLightsGame.InitializeLightsGame();
    }
}
