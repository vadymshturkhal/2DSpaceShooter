using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

/// <summary>
/// Class which manages the game
/// </summary>
public class GameManager : MonoBehaviour
{
    // The highest score obtained by this player
    [Tooltip("The highest score acheived on this device")]
    [SerializeField]
    int highScore = 0;

    public bool isPaused = false;
    string pausePathInHierarchy = "Canvas/PauseScreen";

    [SerializeField]
    GameObject gameVictoryEffect, gameOverEffect;
    GameObject pauseScreen;
    PlayerController controller;

    void Start()
    {
        controller = GetComponent<PlayerController>();

        Transform pause = transform.Find(pausePathInHierarchy);
        if (pause != null)
        {
            pauseScreen = pause.gameObject;
        }
        else
        {
            Debug.LogError("Pause Screen not set to the Game Manager");
        }
    }

    /// <summary>
    /// Description:
    /// Standard Unity function that gets called when the application (or playmode) ends
    /// Input:
    /// none
    /// Return:
    /// void (no return)
    /// </summary>
    void OnApplicationQuit()
    {
        SaveHighScore();
        ResetScore();
    }

    public void PauseScreen(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isPaused = !isPaused;
            controller.paused = isPaused;
            pauseScreen.SetActive(isPaused);
        }

        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void ResetScore()
    {

    }

    public void SaveHighScore()
    {
        
    }


    public void GameVictory()
    {

    }

    public void ClearLevel()
    {
           
    }

    public void GameOver()
    {
        
    }
}
