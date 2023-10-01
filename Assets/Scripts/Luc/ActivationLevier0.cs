using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationLevier1 : MonoBehaviour
{
    [SerializeField] Bone1 codeBone1;
    [SerializeField] GameObject GoBone1;
    [SerializeField] EnigmeBinaire enigmeBinaire;
    string un = "1";
    bool inBone = false;

    private void OnTriggerEnter(Collider other)
    {
        inBone = true;
    }
    private void OnTriggerExit(Collider other)
    {
        inBone = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && inBone==true)
        {
            codeBone1.activationLevier(GoBone1);
            enigmeBinaire.CodePLayer(un);
        }
    }
}
