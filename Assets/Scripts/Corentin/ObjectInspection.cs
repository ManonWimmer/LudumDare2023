using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInspection : MonoBehaviour
{

    //Fields
    [SerializeField] private float inspectSpeed;

    [SerializeField] private GameObject objectInspected;
    [SerializeField] private bool isInspecting;
    [SerializeField] private Canvas inspectorCanvas;
    [SerializeField] private GameObject parentObject;

    [SerializeField] private bool buttonTest;

    private float rotationObjectX;
    private float rotationObjectY;

    private FPSController fpsController;

    [SerializeField] private int miminumInspection;

    //[SerializeField] private bool inspectionPressed;

    private TakeObject takeObject;


    //Properties
    public GameObject ObjectInspected { get => objectInspected; set => objectInspected = value; }


    //Methods
    public void InspectObject(GameObject objectSelectionned)
    {
        isInspecting = true;
        inspectorCanvas.enabled = true;
        GameObject instance = Instantiate(objectSelectionned, parentObject.transform.position, Quaternion.identity, parentObject.transform);
        objectInspected = instance;
        fpsController.enabled = false;

        StartCoroutine(Inspection());
    }
    public void InspectObjectEnd()
    {
        isInspecting = false;
        inspectorCanvas.enabled = false;

        Destroy(objectInspected);
        objectInspected = null;

        Debug.Log("fin de l'inspection");

        fpsController.enabled = true;

        //mettre à jour les valeurs
    }


    private void Awake()
    {
        inspectorCanvas.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        fpsController = GetComponent<FPSController>();

        takeObject = GetComponent<TakeObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(buttonTest)
        {
            buttonTest = false;
            InspectObject(objectInspected);
        }

        //takeObject.LeftPressed = InputManager.GetInstance().GetInteractPressed();

        if(takeObject.LeftPressed)
        {
            Debug.Log(takeObject.LeftPressed);
        }
    }

    private IEnumerator Inspection()
    {
        while (isInspecting)
        {
            float mouseX = InputManager.GetInstance().GetMouseXDelta();
            float mouseY = InputManager.GetInstance().GetMouseYDelta();

            rotationObjectX += -mouseY * inspectSpeed;
            rotationObjectY += -mouseX * inspectSpeed;

            objectInspected.transform.localRotation = Quaternion.Euler(rotationObjectX, rotationObjectY, 0);

            if (takeObject.LeftPressed && miminumInspection >= 1)
            {
                InspectObjectEnd();
                miminumInspection = 0;
            }
            else if(takeObject.LeftPressed)
            {
                miminumInspection++ ;
            }

            yield return null;
        }
    }

}
