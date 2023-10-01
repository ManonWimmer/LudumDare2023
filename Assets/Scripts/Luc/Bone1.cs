using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone1 : MonoBehaviour
{
    [SerializeField] GameObject bone1;
    [SerializeField] int rotationX = 150;
    [SerializeField] EnigmeBinaire enigmeBinaire;
    string un = "1";
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
        if (Input.GetKeyUp(KeyCode.Keypad1))
        {
            activationLevier(bone1);
            enigmeBinaire.CodePLayer(un);
        }

    }
}
