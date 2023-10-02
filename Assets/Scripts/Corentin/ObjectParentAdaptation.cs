using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectParentAdaptation : MonoBehaviour
{

    private float _widthScreen;

    private float _heightScreen;

    private float _diagScreen;

    private float _diagReference;

    private float _diagCoeff;

    private float _globalCoeff;


    //private float _coeffScreen;

    public float DiagCoeff { get => _diagCoeff; set => _diagCoeff = value; }





    //[SerializeField] private Canvas _inspectorCanvas;

    private void Awake()
    {
        _widthScreen = Screen.width;
        _heightScreen = Screen.height;

        _diagScreen = Mathf.Sqrt(Mathf.Pow(_widthScreen, 2) + Mathf.Pow(_heightScreen, 2));

        _diagReference = Mathf.Sqrt(Mathf.Pow(1920, 2) + Mathf.Pow(1080, 2));

        //_coeffScreen = (_diagScreen * (-212f)) / (1920f / 1080f);


        //Test
        Debug.Log(Screen.width);
        Debug.Log(Screen.height);

        Debug.Log("diagScreen = " + _diagScreen);
        Debug.Log("diagScreenRef = " + _diagReference);
        //Debug.Log("diagRef = " + _coeffScreen);

        float _coeffActual = _widthScreen / _heightScreen;

        float _refCoeff = 16f / 9f;

        _globalCoeff = _coeffActual / _refCoeff;

        Mathf.Clamp(_globalCoeff, -212, 0);

        Debug.Log("globalCoef = " + _globalCoeff);

        _diagCoeff = _diagScreen / _diagReference;

        Debug.Log("DiagCoeff = " + _diagCoeff);

        transform.localPosition = new Vector3(0, 0, -212f * _diagCoeff);

    }

    // Start is called before the first frame update
    void Start()
    {
        
        
        
        //transform.localPosition /= (1920f/1080f) / _diagScreen;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
