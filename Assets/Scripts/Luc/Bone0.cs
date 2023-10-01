using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone0 : MonoBehaviour
{
    [SerializeField] GameObject bone0;
    [SerializeField] EnigmeBinaire enigmeBinaire;
    [SerializeField] int rotationX = 150;
    string zero = "0";
    void activationLevier(GameObject bone)
    {
        bone.transform.Rotate(rotationX, 0, 0, Space.Self);
        StartCoroutine(MyCoroutine());
        IEnumerator MyCoroutine()
        {
            yield return new WaitForSeconds(1.0f);
            bone.transform.Rotate(-rotationX, 0, 0, Space.Self);
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Keypad0))
        {
            activationLevier(bone0);
            enigmeBinaire.CodePLayer(zero);
        }

    }
}
