using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenu;

    [SerializeField]
    private GameObject inputsMenu;
    // ----- VARIABLES ----- //

    private void Start()
    {
        mainMenu.SetActive(true);
        inputsMenu.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
    }

    public void OpenMainMenu()
    {
        mainMenu.SetActive(true);
        inputsMenu.SetActive(false);
    }
    public void OpenInputsMenu()
    {
        mainMenu.SetActive(false);
        inputsMenu.SetActive(true);
    }
}
