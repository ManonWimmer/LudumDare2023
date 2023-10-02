using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ClipBoardInteraction : MonoBehaviour
{
    //Fields
    [SerializeField] private GameObject _clipBoard;
    private GameObject _clipBoardInstance;

    [SerializeField] private bool _isOpen;

    [SerializeField] private Canvas _inspectorCanvas;
    [SerializeField] private GameObject _parentObject;

    [SerializeField] private FPSController _fpsController;

    [SerializeField] private float _scrollSpeed;
    private float _positionY;

    [SerializeField] private TextMeshProUGUI _info1;
    [SerializeField] private TextMeshProUGUI _info2;
    [SerializeField] private TextMeshProUGUI _info3;

    //[SerializeField] private Vector3 originalPosition;
    //[SerializeField] private Quaternion originalRotation;

    [SerializeField] private Transform _positionClipBoardStart;

    private bool _canChange;



    //properties
    public bool IsOpen { get => _isOpen; set => _isOpen = value; }
    public bool CanChange { get => _canChange; set => _canChange = value; }

    public void OpenClipBoard()
    {
        if (!_isOpen && !_fpsController.IsInspecting)
        {
            _isOpen = true;
            _inspectorCanvas.enabled = true;

            //GameObject instance = Instantiate(clipBoard, parentObject.transform.position, Quaternion.identity, parentObject.transform);
            //clipBoardInstance = instance;
            //clipBoardInstance.GetComponent<Collider>().isTrigger = true;
            //clipBoardInstance.transform.localRotation = Quaternion.Euler(90, 180, 0);
            //clipBoardInstance.transform.localScale *= 2;

            _clipBoard.transform.parent = _parentObject.transform;

            _clipBoard.transform.localPosition = new Vector3(0, 0, 0);

            _clipBoard.transform.localRotation = Quaternion.Euler(90, 180, 0);

            _clipBoard.transform.localScale *= 2;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Debug.Log(Cursor.lockState);

            StartCoroutine(ClipBoardMod());
        }

    }

    public void CloseClipBoard()
    {
        _isOpen = false;
        _inspectorCanvas.enabled = false;

        _clipBoard.transform.localScale /= 2;

        _clipBoard.transform.parent = null;

        _clipBoard.transform.position = _positionClipBoardStart.position;

        _clipBoard.transform.rotation = _positionClipBoardStart.rotation;
        
        //Destroy(clipBoardInstance);
        //clipBoardInstance=null;

        Debug.Log("fin modification ClipBoard");


        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void NextInfo(TextMeshProUGUI info, int i)
    {
        switch (i)
        {
            case 1:
                switch (info.text)
                {
                    case "Knife":
                        info.text = "Gun";
                        break;

                    case "Gun":
                        info.text = "Rope";
                        break;

                    case "Rope":
                        info.text = "Axe";
                        break;

                    case "Axe":
                        info.text = "Poison";
                        break;

                    case "Poison":
                        info.text = "Knife";
                        break;
                }
                break;
            case 2:
                switch (info.text)
                {
                    case "Lucas Blackwood":
                        info.text = "Isabella Santiago";
                        break;

                    case "Isabella Santiago":
                        info.text = "Max Archer";
                        break;

                    case "Max Archer":
                        info.text = "Evelyn Stone";
                        break;

                    case "Evelyn Stone":
                        info.text = "Victor Thorn";
                        break;

                    case "Victor Thorn":
                        info.text = "Lucas Blackwood";
                        break;
                }
                break;
            case 3:
                switch (info.text)
                {
                    case "Bar":
                        info.text = "Mansion";
                        break;

                    case "Mansion":
                        info.text = "Home";
                        break;

                    case "Home":
                        info.text = "Laboratory";
                        break;

                    case "Laboratory":
                        info.text = "Library";
                        break;

                    case "Library":
                        info.text = "Bar";
                        break;
                }

                break;
        }
    }

    public void LastInfo(TextMeshProUGUI info, int i)
    {
        switch (i)
        {
            case 1:
                switch (info.text)
                {
                    case "Knife":
                        info.text = "Poison";
                        break;

                    case "Gun":
                        info.text = "Knife";
                        break;

                    case "Rope":
                        info.text = "Gun";
                        break;

                    case "Axe":
                        info.text = "Rope";
                        break;

                    case "Poison":
                        info.text = "Axe";
                        break;
                }
                break;
            case 2:
                switch (info.text)
                {
                    case "Lucas Blackwood":
                        info.text = "Victor Thorn";
                        break;

                    case "Isabella Santiago":
                        info.text = "Lucas Blackwood";
                        break;

                    case "Max Archer":
                        info.text = "Isabella Santiago";
                        break;

                    case "Evelyn Stone":
                        info.text = "Max Archer";
                        break;

                    case "Victor Thorn":
                        info.text = "Evelyn Stone";
                        break;
                }
                break;
            case 3:
                switch (info.text)
                {
                    case "Bar":
                        info.text = "Library";
                        break;

                    case "Mansion":
                        info.text = "Bar";
                        break;

                    case "Home":
                        info.text = "Mansion";
                        break;

                    case "Laboratory":
                        info.text = "Home";
                        break;

                    case "Library":
                        info.text = "Laboratory";
                        break;
                }
                break;
        }
    }

    private void Awake()
    {
        //originalPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        //originalRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z);

        _clipBoard.transform.position = _positionClipBoardStart.position;

        _clipBoard.transform.rotation = _positionClipBoardStart.rotation;

        _canChange = true;

    }

    // Start is called before the first frame update
    void Start()
    {
        _fpsController = GetComponent<FPSController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ClipBoardMod()
    {
        while (_isOpen)
        {
            float mouseX = InputManager.GetInstance().GetMouseXDelta();
            float mouseY = InputManager.GetInstance().GetMouseYDelta();

            _positionY += -mouseY * _scrollSpeed * Time.deltaTime;

            _positionY = Mathf.Clamp(_positionY, -0.5f, 0.5f);

            _clipBoard.transform.localPosition = new Vector3 (0, _positionY, 0);


            if (_fpsController.InteractPressed && _canChange)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;

                Debug.DrawRay(ray.origin, ray.direction * 5, Color.red);

                if (Physics.Raycast(ray, out hit, 5f))
                {
                    Transform go = hit.transform;

                    Debug.Log(go);

                    if(go.TryGetComponent<Button>(out Button button))
                    {
                        Debug.Log("j'ai eu le button");
                        
                        if (button.GetComponentInChildren<TextMeshProUGUI>().text == ">")
                        {
                            switch(button.name[button.name.Length - 1])
                            {
                                case '1':
                                    NextInfo(_info1, 1);
                                    break;
                                case '2':
                                    NextInfo(_info2, 2);
                                    break;
                                case '3':
                                    NextInfo(_info3, 3);
                                    break;
                            }
                        }
                        else if(button.GetComponentInChildren<TextMeshProUGUI>().text == "<")
                        {
                            switch (button.name[button.name.Length - 1])
                            {
                                case '1':
                                    LastInfo(_info1, 1);
                                    break;
                                case '2':
                                    LastInfo(_info2, 2);
                                    break;
                                case '3':
                                    LastInfo(_info3, 3);
                                    break;
                            }
                        }
                    }
                    else
                    {
                        Debug.Log("Pas de dropDown");
                    }
                }
            }


            if (Input.GetKeyDown(KeyCode.Escape))
            {
                CloseClipBoard();
            }
            yield return null;
        }
    }
}
