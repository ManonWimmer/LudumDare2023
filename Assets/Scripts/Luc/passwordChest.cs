using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class passwordChest : MonoBehaviour
{
    private void Start()
    {
        canvas.SetActive(false);
    }
    [SerializeField] Collider Collider;
    [SerializeField] GameObject canvas;
    [SerializeField] FPSController fpsController;
    [SerializeField] InputField passwordInput;

    private void OnTriggerEnter(Collider other)
    {
        canvas.SetActive(true);
        fpsController.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        string playerPassword= passwordInput.text.ToString();
        Debug.Log(testPassword(playerPassword));
    }
    private void OnTriggerExit(Collider other)
    {
        canvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
    bool testPassword(string password)
    {
        if(password == "792")
        {
            return true;
        }
        return false;
    }
     
    
}
