using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone1 : MonoBehaviour
{
    [SerializeField] int rotationX = 150;
    [SerializeField] EnigmeBinaire enigmeBinaire;
    [SerializeField] Sound Sound;
    public void activationLevier(GameObject bone)
    {
        bone.transform.Rotate(rotationX, 0, 0, Space.Self);
        Sound.playSound();
        StartCoroutine(MyCoroutine());
        IEnumerator MyCoroutine()
        {
            yield return new WaitForSeconds(1.0f);
            bone.transform.Rotate(-rotationX, 0, 0, Space.Self);
            Sound.playSound();
        }
    }
}
