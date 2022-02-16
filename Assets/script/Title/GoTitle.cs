using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoTitle : MonoBehaviour
{
//    AudioSource audioSource;
//    [SerializeField] public AudioClip m_push;
    // Start is called before the first frame update
    public void GoScene()
    {
        //audioSource.PlayOneShot(m_push);
        SceneManager.LoadScene("Title");
    }

}
