using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectParentAdaptation : MonoBehaviour
{

    private float _widthScreen;

    private float _heightScreen;

    private float _diagScreen;

    private float _coeffScreen;

    public float DiagScreen { get => _diagScreen; set => _diagScreen = value; }



    //[SerializeField] private Canvas _inspectorCanvas;

    private void Awake()
    {
        _widthScreen = Screen.width;
        _heightScreen = Screen.height;

        _diagScreen = _widthScreen / _heightScreen;



        _coeffScreen = (_diagScreen * (-212f)) / (1920f / 1080f);

        
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Screen.width);
        Debug.Log(Screen.height);

        Debug.Log("screendiag = " + _diagScreen);
        Debug.Log("screencoeff = " + _coeffScreen);

        //transform.position = new Vector3(0, 0, _coeffScreen);
        transform.localPosition /= (1920f/1080f) / _diagScreen;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
