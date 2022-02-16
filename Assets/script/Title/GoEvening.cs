using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoEvening : MonoBehaviour
{
//    AudioSource audioSource;
//    [SerializeField] public AudioClip m_push;
    public void GoScene()
    {
        SceneManager.LoadScene("Evening");
    }
}
