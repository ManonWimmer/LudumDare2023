using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MusiqueInterogationRoom : MonoBehaviour
{
    private AudioSource _playerAudioSource;

    [SerializeField] private AudioClip[] _playList;

    private int _playListIndex = 0;



    //Methods
    public void PlayNextMusic()
    {
        _playListIndex++;
        if (_playListIndex == 2)
        {
            _playListIndex = 0;
        }
        _playerAudioSource.clip = _playList[_playListIndex];
        _playerAudioSource.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        _playerAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if( _playerAudioSource.isPlaying == false)
        {
            PlayNextMusic();
        }
    }
}
