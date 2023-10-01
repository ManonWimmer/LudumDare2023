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

    [SerializeField] private ClipBoardInteraction clipBoardInteraction;

    //[SerializeField] private bool inspectionPressed;

    private TakeObject takeObject;


    //Properties
    public GameObject ObjectInspected { get => objectInspected; set => objectInspected = value; }
    public bool IsInspecting { get => isInspecting; set => isInspecting = value; }


    //Methods
    public void InspectObject(GameObject objectSelectionned)
    {
        if (!clipBoardInteraction.IsOpen)
        {
            isInspecting = true;

            inspectorCanvas.enabled = true;

            GameObject instance = Instantiate(objectSelectionned, parentObject.transform.position, Quaternion.identity, parentObject.transform);
            objectInspected = instance;
            objectInspected.GetComponent<Collider>().isTrigger = true;


            StartCoroutine(Inspection());
        }
    }
    public void InspectObjectEnd()
    {
        isInspecting = false;
        inspectorCanvas.enabled = false;

        Destroy(objectInspected);
        objectInspected = null;

        Debug.Log("fin de l'inspection");


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
        if (isInspecting || clipBoardInteraction.IsOpen)
        {
            fpsController.IsInspecting = true;
        }
        else
        {
            fpsController.IsInspecting = false;
        }

        if(buttonTest)
        {
            buttonTest = false;
            InspectObject(objectInspected);
        }

        //takeObject.LeftPressed = InputManager.GetInstance().GetInteractPressed();

        if(fpsController.InteractPressed)
        {
            Debug.Log(fpsController.InteractPressed);
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

            if (miminumInspection > 1)
            {
                InspectObjectEnd();
                miminumInspection = 0;
            }
            else if(fpsController.InteractPressed)
            {
                miminumInspection++ ;
            }

            yield return null;
        }
    }

}
