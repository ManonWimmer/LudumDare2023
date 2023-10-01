using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigOfficeTrigger : MonoBehaviour
{

    [SerializeField] OpenOffice openOffice;
    private bool canBeToggled = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Player dans la salle
        {
            if (canBeToggled)
            {
                openOffice.ToggleOffice();
                canBeToggled = false;
            }
        }
    }
}
