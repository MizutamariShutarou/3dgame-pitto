using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoExplanation : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] public AudioClip m_push;
    public void GoScene()
    {
        //audioSource.PlayOneShot(m_push);
        SceneManager.LoadScene("Explanation");
    }
}
