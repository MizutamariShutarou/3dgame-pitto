using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoMorning : MonoBehaviour
{
    //AudioSource audioSource;
    //[SerializeField] public AudioClip m_push;
    //// Start is called before the first frame update
    //public void Oudio()
    //{
    //    audioSource.PlayOneShot(m_push);
    //}
    public void GoScene()
    {
        
        SceneManager.LoadScene("Morning");
    }
}
