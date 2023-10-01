using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    private bool lightOn = false;
    private float rotationX = 0;
    [SerializeField] float lookSpeed = 0.2f;
    [SerializeField] float lookXLimit = 80f;
    [SerializeField] Transform lightTransform;
    [SerializeField] Light lightComp;

    private void Update()
    {
        CheckInput();

        if (lightOn)
        {
            lightComp.enabled = true;
            float mouseX = InputManager.GetInstance().GetMouseXDelta();
            float mouseY = InputManager.GetInstance().GetMouseYDelta();

            rotationX += -mouseY * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            lightTransform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            lightTransform.rotation *= Quaternion.Euler(0, mouseX * lookSpeed, 0);
        }
        else
        {
            lightComp.enabled = false;
        }
    }

    private void CheckInput()
    {
        if (InputManager.GetInstance().GetFlashLightPressed())
        {
            lightOn = !lightOn;
            Debug.Log(lightOn);
        }
    }
}
