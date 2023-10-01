using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    // ----- VARIABLES ----- //
    [SerializeField] Camera playerCamera;
    [SerializeField] float walkSpeed = 6f;
    [SerializeField] float runSpeed = 12f;
    [SerializeField] float gravity = 10f;
    [SerializeField] float lookSpeed = 2f;
    [SerializeField] float lookXLimit = 45f;
    [SerializeField] float defaultHeight = 2f;

    private Vector3 moveDirection = Vector3.zero;
    private bool interactPressed = false;
    private float rotationX = 0;
    private CharacterController characterController;

    private bool canMove = true;

    private bool isInspecting;

    public bool InteractPressed { get => interactPressed; set => interactPressed = value; }
    public bool IsInspecting { get => isInspecting; set => isInspecting = value; }

    // ----- VARIABLES ----- //

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        interactPressed = InputManager.GetInstance().GetInteractPressed();
        if (!IsInspecting)
        {
            if (Physics.Raycast(ray, out hit, 200) && interactPressed)
            {
                Debug.DrawRay(Camera.main.transform.position, ray.direction * hit.distance, Color.yellow);

                Transform tempTransform;
                tempTransform = hit.transform;

                if (tempTransform.gameObject.CompareTag("Drawer"))
                {
                    Debug.Log("DRAWER");
                    tempTransform.gameObject.GetComponent<Drawer>().ToggleDrawer();
                }
                else if (tempTransform.gameObject.CompareTag("Interactive"))
                {
                    Debug.Log("Interactive");
                    GetComponent<ObjectInspection>().InspectObject(tempTransform.gameObject);
                }
                else if (tempTransform.gameObject.CompareTag("ClipBoard"))
                {
                    Debug.Log("ClipBoard");
                    GetComponent<ClipBoardInteraction>().OpenClipBoard();
                }
            }
        }
        
        if(!isInspecting)
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);

            Vector2 inputDirection = InputManager.GetInstance().GetMoveDirection();

            bool isRunning = Input.GetKey(KeyCode.LeftShift);
            float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * inputDirection.y : 0;
            float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * inputDirection.x : 0;
            float movementDirectionY = moveDirection.y;
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        
            if (!characterController.isGrounded)
            {
                moveDirection.y -= gravity * Time.deltaTime;
            }

            characterController.height = defaultHeight;
            walkSpeed = 6f;
            runSpeed = 12f;

            characterController.Move(moveDirection * Time.deltaTime);

            if (canMove)
            {
                float mouseX = InputManager.GetInstance().GetMouseXDelta();
                float mouseY = InputManager.GetInstance().GetMouseYDelta();

                rotationX += -mouseY * lookSpeed;
                rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
                playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
                transform.rotation *= Quaternion.Euler(0, mouseX * lookSpeed, 0);
            }
        }
    }
}