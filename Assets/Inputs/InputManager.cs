using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //

public class InputManager : MonoBehaviour
{
    // ----- VARIABLES ----- //
    private Vector2 moveDirection = Vector2.zero;
    private float mouseXDelta;
    private float mouseYDelta;
    private bool interactPressed = false;

    [SerializeField]
    private PlayerInput playerInput;

    private string deviceUsed { get; set; }

    private static InputManager instance;
    // ----- VARIABLES ----- //

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Plus d'un Input Manager dans la scène");
        }

        instance = this;
    }

    public static InputManager GetInstance()
    {
        return instance;
    }

    public void MovePressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            moveDirection = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            moveDirection = context.ReadValue<Vector2>();
        }
    }

    public void MouseXMoved(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            mouseXDelta = context.ReadValue<float>();
        }
        else if (context.canceled)
        {
            mouseXDelta = context.ReadValue<float>();
        }
    }

    public void MouseYMoved(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            mouseYDelta = context.ReadValue<float>();
        }
        else if (context.canceled)
        {
            mouseYDelta = context.ReadValue<float>();
        }
    }

    public void InteractPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            interactPressed = true;
        }
        else if (context.canceled)
        {
            interactPressed = false;
        }
    }

    public Vector2 GetMoveDirection()
    {
        return moveDirection;
    }

    public float GetMouseXDelta()
    {
        return mouseXDelta;
    }

    public float GetMouseYDelta()
    {
        return mouseYDelta;
    }

    public bool GetInteractPressed()
    {
        bool result = interactPressed;
        interactPressed = false;
        return result;
    }

    private void UpdateDevice()
    {
        deviceUsed = playerInput.currentControlScheme;
    }

    public void OnControlsChanged()
    {
        Debug.Log("controls changed");
        UpdateDevice();
    }
}
