using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInspection : MonoBehaviour
{

    //Fields
    [SerializeField] private float inspectSpeed;

    [SerializeField] private GameObject objectInspected;
    private bool isInspecting;
    [SerializeField] private Canvas inspectorCanvas;
    [SerializeField] private GameObject parentObject;

    [SerializeField] private bool buttonTest;

    private float rotationObjectX;
    private float rotationObjectY;

    private FPSController fpsController;

    //Properties

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
        objectInspected = null;
        fpsController.enabled = true;
    }


    private void Awake()
    {
        inspectorCanvas.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        fpsController = GetComponent<FPSController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(buttonTest)
        {
            buttonTest = false;
            InspectObject(objectInspected);
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

            yield return null;
        }
    }

}
