using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    int score = 0; 

    public int GetScore()
    {
        return score; 
    }

    public void AddToScore(int scoreValue)
    {
        score += scoreValue; 
    }

    public void ResetGame()
    {
        Destroy(gameObject); 
    }
    void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        // if there is more than one GameSession destroy the last one created.
        if (FindObjectsOfType<GameSession>().Length > 1)
        {
            Destroy(gameObject);
        }
        else // only one GameSession is found
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
