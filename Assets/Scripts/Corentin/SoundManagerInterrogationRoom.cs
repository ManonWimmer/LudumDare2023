using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerInterrogationRoom : MonoBehaviour
{
    private AudioSource _playerAudioSource;

    [SerializeField] private AudioClip _paperPageClip;

    [SerializeField] private AudioClip _clipBoardClip;

    [SerializeField] private AudioClip _tickClip;

    [SerializeField] private AudioClip _correctClip;

    // Start is called before the first frame update
    void Start()
    {
        _playerAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PageSound()
    {

        Debug.Log("Son de page");
        _playerAudioSource.PlayOneShot(_paperPageClip);
    }

    public void ClipBoardSound()
    {
        Debug.Log("Son clipBoard");
        _playerAudioSource.PlayOneShot(_clipBoardClip);
    }

    public void TickSound()
    {
        Debug.Log("tick");
        _playerAudioSource.PlayOneShot(_tickClip);
    }

    public void CorrectClipSound()
    {
        Debug.Log("Correct");
        _playerAudioSource.PlayOneShot(_correctClip, 0.25f);
    }
}
