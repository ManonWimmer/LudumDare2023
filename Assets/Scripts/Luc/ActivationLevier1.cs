using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationLevier0 : MonoBehaviour
{
    [SerializeField] Bone1 codeBone0;
    [SerializeField] GameObject GoBone0;
    [SerializeField] EnigmeBinaire enigmeBinaire;
    string zero = "0";
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
            codeBone0.activationLevier(GoBone0);
            enigmeBinaire.CodePLayer(zero);
        }
    }
}
