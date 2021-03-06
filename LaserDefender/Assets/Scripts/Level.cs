﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 2f;

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("GameOver");
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Laserdefender");
        GameSession gs = FindObjectOfType<GameSession>();
        if(gs != null)
        {
            gs.ResetGame();
        }

    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        print("Quitting Game");
        //will only work as EXE
        Application.Quit();
    }
}
