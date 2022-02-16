using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] public AudioClip m_push;
    // Start is called before the first frame update
    public void Oudio()
    {
        audioSource.PlayOneShot(m_push);
    }
    
}
