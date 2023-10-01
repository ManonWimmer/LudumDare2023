using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class EnigmeBinaire : MonoBehaviour
{
    [SerializeField] GameObject bone0;
    [SerializeField] GameObject bone1;
    private string codePlayer="";
    [SerializeField] TextMeshProUGUI textMeshPro;
    [SerializeField] TextMeshProUGUI textMeshProPW;

    public void CodePLayer(string chiffre)
    {
        codePlayer += chiffre;
        textMeshPro.text = codePlayer;
        if (codePlayer.Length == 3)
        {
            if (codePlayer == "000")
            {
                textMeshProPW.text += "0";

            }
            else if(codePlayer == "001")
            {
                textMeshProPW.text += "1";
            }
            else if (codePlayer == "010")
            {
                textMeshProPW.text += "2";
            }
            else if (codePlayer == "011")
            {
                textMeshProPW.text += "3";
            }
            else if (codePlayer == "100")
            {
                textMeshProPW.text += "4";
            }
            else if (codePlayer == "101")
            {
                textMeshProPW.text += "5";
            }
            else if (codePlayer == "110")
            {
                textMeshProPW.text += "6";
            }
            else if (codePlayer == "111")
            {
                textMeshProPW.text += "7";
            }
            codePlayer = "";
            StartCoroutine(MyCoroutine());
            IEnumerator MyCoroutine()
            {
                yield return new WaitForSeconds(1.0f);
                textMeshPro.text = codePlayer;
            }
            
            if(textMeshProPW.text=="206") 
            {
                StartCoroutine(MyCoroutine1());
                IEnumerator MyCoroutine1()
                {
                    yield return new WaitForSeconds(1.0f);
                    textMeshProPW.text = "Open";
                    
                }
                Debug.Log("Win");
            }else if(textMeshProPW.text.Length == 3 && textMeshProPW.text != "206")
            {
                StartCoroutine(MyCoroutine2());
                IEnumerator MyCoroutine2()
                {
                    yield return new WaitForSeconds(1.0f);
                    textMeshProPW.text = "Close";
                    yield return new WaitForSeconds(3.0f);
                    textMeshProPW.text = "";
                }
            }

        }
    }
}
