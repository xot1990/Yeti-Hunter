using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControler : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip Main;
    public AudioClip Boss;

    void Start()
    {
        audioSource.GetComponent<AudioSource>();
    }

    
    void Update()
    {
        
    }
}
