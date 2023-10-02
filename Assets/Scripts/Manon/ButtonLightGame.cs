using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLightGame : MonoBehaviour
{
    [SerializeField] LightGame lightGame;
    [SerializeField] AllLightsGame allLightsGame;

    public void ButtonPressed()
    {
        if (!allLightsGame.GameVictory) // Pas encore gagné -> il peut appuyer sur le bouton
            lightGame.ButtonLightPressed();
    }
}
