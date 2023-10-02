using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadCorridor3 : MonoBehaviour
{
    [SerializeField] EnigmeBinaire enigmeBinaire;
    bool inCollider = false;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        inCollider = true;
    }
    private void OnTriggerExit(Collider other)
    {
        inCollider = false;
    }   

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && inCollider && enigmeBinaire.finPartie)
        {
            SceneManager.LoadScene("Couloir3");
        }
    }
}
