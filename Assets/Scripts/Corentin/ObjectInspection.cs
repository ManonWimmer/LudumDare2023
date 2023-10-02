using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInspection : MonoBehaviour
{

    //Fields
    [Header("Inspect Attributes")]

    [SerializeField] private float _inspectSpeed;

    [SerializeField] private GameObject _objectInspected;
    [SerializeField] private bool _isInspecting;
    [SerializeField] private Canvas _inspectorCanvas;
    [SerializeField] private GameObject _parentObject;

    private float _rotationObjectX;
    private float _rotationObjectY;

    private FPSController _fpsController;

    private int _miminumInspection;

   [SerializeField] private float _sizeCorrection;

    [Header ("! Only in interogation room")]

    [SerializeField] private ClipBoardInteraction _clipBoardInteraction;

    //[SerializeField] private bool inspectionPressed;

    //private TakeObject takeObject;


    //Properties
    public GameObject ObjectInspected { get => _objectInspected; set => _objectInspected = value; }
    public bool IsInspecting { get => _isInspecting; set => _isInspecting = value; }


    //Methods
    public void InspectObject(GameObject objectSelectionned)
    {
        if(_clipBoardInteraction != null)
        {
            if (!_clipBoardInteraction.IsOpen)
            {
                _isInspecting = true;

                _inspectorCanvas.enabled = true;

                GameObject instance = Instantiate(objectSelectionned, _parentObject.transform.position, Quaternion.identity, _parentObject.transform);
                _objectInspected = instance;
                _objectInspected.GetComponent<Collider>().isTrigger = true;
                _objectInspected.transform.localScale *= _sizeCorrection;


                StartCoroutine(Inspection());
            }
        }
        else
        {
            _isInspecting = true;

            _inspectorCanvas.enabled = true;

            GameObject instance = Instantiate(objectSelectionned, _parentObject.transform.position, Quaternion.identity, _parentObject.transform);
            _objectInspected = instance;
            _objectInspected.GetComponent<Collider>().isTrigger = true;
            _objectInspected.transform.localScale *= _sizeCorrection;


            StartCoroutine(Inspection());
        }
        
    }
    public void InspectObjectEnd()
    {
        _isInspecting = false;
        _inspectorCanvas.enabled = false;

        Destroy(_objectInspected);
        _objectInspected = null;

        Debug.Log("fin de l'inspection");

    }


    private void Awake()
    {
        _inspectorCanvas.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        _fpsController = GetComponent<FPSController>();

        //takeObject = GetComponent<TakeObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_clipBoardInteraction != null)
        {
            if (_isInspecting || _clipBoardInteraction.IsOpen)
            {
                _fpsController.IsInspecting = true;
            }
            else
            {
                _fpsController.IsInspecting = false;
            }
        }
        else
        {
            if (_isInspecting)
            {
                _fpsController.IsInspecting = true;
            }
            else
            {
                _fpsController.IsInspecting = false;
            }
        }
        

        //takeObject.LeftPressed = InputManager.GetInstance().GetInteractPressed();

        if(_fpsController.InteractPressed)
        {
            Debug.Log(_fpsController.InteractPressed);
        }
    }

    private IEnumerator Inspection()
    {
        while (_isInspecting)
        {
            float mouseX = InputManager.GetInstance().GetMouseXDelta();
            float mouseY = InputManager.GetInstance().GetMouseYDelta();

            _rotationObjectX += -mouseY * _inspectSpeed;
            _rotationObjectY += -mouseX * _inspectSpeed;

            _objectInspected.transform.localRotation = Quaternion.Euler(_rotationObjectX, _rotationObjectY, 0);

            if (_miminumInspection > 1)
            {
                InspectObjectEnd();
                _miminumInspection = 0;
            }
            else if(_fpsController.InteractPressed)
            {
                _miminumInspection++ ;
            }

            yield return null;
        }
    }

}
