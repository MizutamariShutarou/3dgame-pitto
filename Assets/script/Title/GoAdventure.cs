﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoAdventure : MonoBehaviour
{
    // Start is called before the first frame update
    public void GoScene()
    {
        SceneManager.LoadScene("AdvMorning");
    }
}