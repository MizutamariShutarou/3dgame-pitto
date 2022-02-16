using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoEvening : MonoBehaviour
{
   
    public void GoScene()
    {
        SceneManager.LoadScene("Evening");
    }
}
