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
    [SerializeField] private GameObject clipBoard;
    [SerializeField] private GameObject clipBoardInstance;

    [SerializeField] private bool isOpen;

    [SerializeField] private Canvas inspectorCanvas;
    [SerializeField] private GameObject parentObject;

    [SerializeField] private FPSController fpsController;

    [SerializeField] private float scrollSpeed;
    private float positionY;

    [SerializeField] private string weapon;
    [SerializeField] private string place;
    [SerializeField] private string suspect;

    [SerializeField] private TextMeshProUGUI info1;
    [SerializeField] private TextMeshProUGUI info2;
    [SerializeField] private TextMeshProUGUI info3;

    //[SerializeField] private Vector3 originalPosition;
    //[SerializeField] private Quaternion originalRotation;

    [SerializeField] private Transform positionClipBoardStart;



    //properties
    public bool IsOpen { get => isOpen; set => isOpen = value; }


    public void OpenClipBoard()
    {
        if (!isOpen && !fpsController.IsInspecting)
        {
            isOpen = true;
            inspectorCanvas.enabled = true;

            //GameObject instance = Instantiate(clipBoard, parentObject.transform.position, Quaternion.identity, parentObject.transform);
            //clipBoardInstance = instance;
            //clipBoardInstance.GetComponent<Collider>().isTrigger = true;
            //clipBoardInstance.transform.localRotation = Quaternion.Euler(90, 180, 0);
            //clipBoardInstance.transform.localScale *= 2;

            clipBoard.transform.parent = parentObject.transform;

            clipBoard.transform.localPosition = new Vector3(0, 0, 0);

            clipBoard.transform.localRotation = Quaternion.Euler(90, 180, 0);

            clipBoard.transform.localScale *= 2;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Debug.Log(Cursor.lockState);

            StartCoroutine(ClipBoardMod());
        }

    }

    public void CloseClipBoard()
    {
        isOpen = false;
        inspectorCanvas.enabled = false;

        clipBoard.transform.localScale /= 2;

        clipBoard.transform.parent = null;

        clipBoard.transform.position = positionClipBoardStart.position;

        clipBoard.transform.rotation = positionClipBoardStart.rotation;
        
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
                        info.text = "Manor";
                        break;

                    case "Manor":
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

                    case "Manor":
                        info.text = "Bar";
                        break;

                    case "Home":
                        info.text = "Manor";
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

        clipBoard.transform.position = positionClipBoardStart.position;

        clipBoard.transform.rotation = positionClipBoardStart.rotation;
    }

    // Start is called before the first frame update
    void Start()
    {
        fpsController = GetComponent<FPSController>();
    }

    // Update is called once per frame
    void Update()
    {
        weapon = info1.text;
        suspect = info2.text;
        place = info3.text;
    }

    IEnumerator ClipBoardMod()
    {
        while (isOpen)
        {
            float mouseX = InputManager.GetInstance().GetMouseXDelta();
            float mouseY = InputManager.GetInstance().GetMouseYDelta();

            positionY += -mouseY * scrollSpeed * Time.deltaTime;

            positionY = Mathf.Clamp(positionY, -0.5f, 0.5f);

            clipBoard.transform.localPosition = new Vector3 (0, positionY, 0);


            if (fpsController.InteractPressed)
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
                                    NextInfo(info1, 1);
                                    break;
                                case '2':
                                    NextInfo(info2, 2);
                                    break;
                                case '3':
                                    NextInfo(info3, 3);
                                    break;
                            }
                        }
                        else if(button.GetComponentInChildren<TextMeshProUGUI>().text == "<")
                        {
                            switch (button.name[button.name.Length - 1])
                            {
                                case '1':
                                    LastInfo(info1, 1);
                                    break;
                                case '2':
                                    LastInfo(info2, 2);
                                    break;
                                case '3':
                                    LastInfo(info3, 3);
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


            if (Input.GetKeyDown(KeyCode.E))
            {
                CloseClipBoard();
            }
            yield return null;
        }
    }
}
