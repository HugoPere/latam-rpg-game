﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Game : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("battle_scene");
    }
}
