using UnityEngine;

public class Sound : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void playSound()
    {
        audioSource.Play();
    }
    
}
