using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenOffice : MonoBehaviour
{
    private bool isOfficeOpen = false;
    
    [SerializeField] s3DBButton_password buttonPassword;
    [SerializeField] Drawer leftDoor;
    [SerializeField] Drawer rightDoor;


    private void Update()
    {
        bool newOfficeOpen = buttonPassword.passwordFound;
        if (isOfficeOpen != newOfficeOpen)
        {
            isOfficeOpen = newOfficeOpen;
            ToggleOffice();
        }


    }

    public void ToggleOffice()
    {
        leftDoor.ToggleDrawer();
        rightDoor.ToggleDrawer();
    }


}
