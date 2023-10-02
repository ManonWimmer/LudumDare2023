using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageCreation : MonoBehaviour
{
    [SerializeField] private SoundManagerInterrogationRoom soundManagerInterrogation;

    // Start is called before the first frame update
    void Start()
    {
        soundManagerInterrogation.PageSound();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
