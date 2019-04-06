using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// Controls GameOver Screen.
/// </summary>
public class GameManager : HighscoreManager
{
    bool GameEnd = false;

    /// <summary>
    /// if player dies the method is called and the gameover screen is activated.
    /// </summary>
    public void GameOver()
    {
        UpdateScores(Username, PlayerController.points);
        if (GameEnd == false)
        {
            GameEnd = true;
            Destroy(gameObject);
            FindObjectOfType<GameOverScreen>().OnGameOverEvent();
            
        }       
    }
}
