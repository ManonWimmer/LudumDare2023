using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToCorridorTrigger : MonoBehaviour
{
    [SerializeField] private AllLightsGame allLightsGame;
    [SerializeField] private Loading loading;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Player dans la salle
        {
            if (allLightsGame.GameVictory) // player lock
            {
                loading.LoadScene();
            }
        }
    }
}
