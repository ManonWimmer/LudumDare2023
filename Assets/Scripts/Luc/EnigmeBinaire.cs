using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class EnigmeBinaire : MonoBehaviour
{
    [SerializeField] GameObject bone0;
    [SerializeField] GameObject bone1;
    private string codeBinaire = "1001";
    private string codePlayer="";
    [SerializeField] TextMeshProUGUI textMeshPro;


    public void CodePLayer(string chiffre)
    {
        if (codePlayer.Length >= 4)
        {
            codePlayer = "";
        }
        codePlayer += chiffre;
        string texte = textMeshPro.text;
        Debug.Log("TextMeshPro Text: " + texte);
        Debug.Log(codePlayer);
    }
}
