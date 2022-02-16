using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoExplanation : MonoBehaviour
{
    public void GoScene()
    {
        SceneManager.LoadScene("Explanation");
    }
}
