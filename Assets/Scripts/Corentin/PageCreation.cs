using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageCreation : MonoBehaviour
{
    [SerializeField] private SoundManagerInterrogationRoom soundManagerInterrogation;

    private bool _firstAppearance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_firstAppearance)
        {
            _firstAppearance = false;
            soundManagerInterrogation.PageSound();
        }
    }
}
