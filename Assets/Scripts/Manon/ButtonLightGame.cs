using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLightGame : MonoBehaviour
{
    [SerializeField] LightGame lightGame;

    public void ButtonPressed()
    {
        lightGame.ButtonLightPressed();
    }
}
