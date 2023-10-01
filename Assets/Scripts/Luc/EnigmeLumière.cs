using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnigmeLumière : MonoBehaviour
{
    [SerializeField] Light light1;
    [SerializeField] Light light2;
    [SerializeField] Light light3;

    private void Start()
    {
        StartCoroutine(MyCoroutine());
    }
    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(5.0f);
        light1.intensity = 0.9f;
        yield return new WaitForSeconds(0.2f);
        light1.intensity = 2.3f;
        yield return new WaitForSeconds(2.8f);
        light2.intensity = 2.5f;
        yield return new WaitForSeconds(0.2f);
        light2.intensity = 6.3f;
        yield return new WaitForSeconds(2.0f);
        light1.intensity = 0.9f;
        yield return new WaitForSeconds(0.2f);
        light1.intensity = 2.3f;
        yield return new WaitForSeconds(1.4f);
        light1.intensity = 0.9f;
        light3.intensity = 2.5f;
        yield return new WaitForSeconds(0.2f);
        light1.intensity = 2.3f;
        light3.intensity = 6.3f;
        yield return new WaitForSeconds(0.5f);
        light2.intensity = 2.5f;
        yield return new WaitForSeconds(0.5f);
        light2.intensity = 6.3f;

        StartCoroutine(MyCoroutine());
    }
}
