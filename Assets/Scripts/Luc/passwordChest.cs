using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class passwordChest : MonoBehaviour
{
    [SerializeField] Collider Collider;
    [SerializeField] GameObject canvas;
    public TMP_InputField inputField;
    private string userInput;

    private void Start()
    {
        canvas.SetActive(false);
        if (inputField != null)
        {
            inputField.onValueChanged.AddListener(UpdateUserInput);
        }
    }
    

    private void OnTriggerEnter(Collider other)
    {
        canvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
    private void OnTriggerExit(Collider other)
    {
        canvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    private void UpdateUserInput(string newText)
    {
        userInput = newText;
        if (userInput == "792")
        {
            Debug.Log("trouver");
        }
    }

}
