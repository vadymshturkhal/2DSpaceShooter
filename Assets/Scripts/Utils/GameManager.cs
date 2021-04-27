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
    bool isGameOver;
    string allScreensPath = "Canvas";
    string pausePath = "PauseScreen";
    string gameOverPath = "GameOverScreen";

    [SerializeField]
    GameObject gameVictoryEffect, gameOverEffect;
    GameObject pauseScreen;
    GameObject gameOverScreen;
    PlayerController controller;

    void Start()
    {
        controller = GetComponent<PlayerController>();
        pauseScreen = InitializeScreen(pausePath);
        gameOverScreen = InitializeScreen(gameOverPath);

        EventManager.AddGameOverListener(GameOverScreen);
    }

    GameObject InitializeScreen(string pathToScreen)
    {
        GameObject tmp = GameObject.Find(allScreensPath);

        Transform tmpTransform = tmp.transform.Find(pathToScreen);
        if (tmpTransform != null)
        {
            return tmpTransform.gameObject;
        }
        else
        {
            Debug.LogError("Pause Screen not set to the Game Manager");
            return null;
        }
    }

    public void PauseScreen(InputAction.CallbackContext context)
    {
        if (context.started && !isGameOver)
        {
            RevertPause(pauseScreen);
        }
    }

    void GameOverScreen()
    {
        isGameOver = true;
        if (isPaused)
        {
            pauseScreen.SetActive(false);
            gameOverScreen.SetActive(true);
        }
        else
        {
            RevertPause(gameOverScreen);
        }
    }

    void RevertPause(GameObject screenToShow)
    {
        isPaused = !isPaused;
        controller.paused = isPaused;
        screenToShow.SetActive(isPaused);

        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void ToGame()
    {
        RevertPause(pauseScreen);
    }
}
