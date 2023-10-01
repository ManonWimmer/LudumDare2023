using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone0 : MonoBehaviour
{
    [SerializeField] EnigmeBinaire enigmeBinaire;
    [SerializeField] int rotationX = 150;
    public void activationLevier(GameObject bone)
    {
        bone.transform.Rotate(rotationX, 0, 0, Space.Self);
        StartCoroutine(MyCoroutine());
        IEnumerator MyCoroutine()
        {
            yield return new WaitForSeconds(1.0f);
            bone.transform.Rotate(-rotationX, 0, 0, Space.Self);
        }
    }
}
