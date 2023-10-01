using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigOfficeTrigger : MonoBehaviour
{

    [SerializeField] OpenOffice openOffice;
    [SerializeField] LightsOnOff lightsOnOff;
    [SerializeField] AllLightsGame allLightsGame;
    private bool canBeToggled = true;
    private bool playerLocked = false;

    public bool PlayerLocked { get => playerLocked; private set => playerLocked = value; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Player dans la salle
        {
            if (canBeToggled) // player lock
            {
                openOffice.ToggleOffice();
                canBeToggled = false;
                playerLocked = true;
                lightsOnOff.StopMorse();
                allLightsGame.InitializeLightsGame();
            }
        }
    }
}
