using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeObject : MonoBehaviour
{

    //Fields
    [SerializeField] private float inspectRange;

    [SerializeField] private ObjectInspection objectInspection;

    [SerializeField] private bool leftPressed;

    [SerializeField] private Camera mainCamera;

    [SerializeField] private FPSController fPSController;


    //Properties
    public bool LeftPressed { get => leftPressed; set => leftPressed = value; }


    //Methods

    //private void TrySearching()
    //{
    //    int layerMask = 1 << 6;

    //    RaycastHit hit;

    //    Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

    //    if(Physics.Raycast(ray, out hit, inspectRange, 1 << 6))
    //    {
    //        Debug.DrawRay(mainCamera.transform.position, ray.direction * hit.distance, Color.yellow);
    //        Debug.Log("Did hit !");

    //        Transform go = hit.transform;

    //        objectInspection.InspectObject(go.gameObject);
    //    }
    //    else
    //    {
    //        Debug.DrawRay(mainCamera.transform.position, transform.TransformDirection(Vector3.forward) * inspectRange, Color.yellow, 5f);
    //        Debug.Log("Did not hit");
    //    }
    //}

    private void Awake()
    {
        objectInspection = GetComponent<ObjectInspection>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fPSController.enabled == true)
        {
            leftPressed = false;
        }else
        {
            //TrySearching();

            leftPressed = InputManager.GetInstance().GetInteractPressed();
        }
    }
}
