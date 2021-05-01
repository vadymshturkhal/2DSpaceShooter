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
    const string AllScreensPath = "Canvas";
    const float VictoryScreenTimeOut = 2f;

    bool isGameOver;
    bool isPaused = false;

    int enemiesQuantity = 0;

    [SerializeField]
    [Range(0, 1f)]
    float pauseSoundVolume = 0.5f;

    string pausePath = "PauseScreen";
    string gameOverPath = "GameOverScreen";
    string levelCompletedPath = "LevelCompletedScreen";

    GameObject pauseScreen;
    GameObject gameOverScreen;
    GameObject levelCompletedScreen;
    PlayerController controller;

    [SerializeField]
    AudioClipName pauseSound;
    [SerializeField]
    AudioClipName levelSound;

    void Start()
    {
        controller = GetComponent<PlayerController>();
        pauseScreen = InitializeScreen(pausePath);
        gameOverScreen = InitializeScreen(gameOverPath);
        levelCompletedScreen = InitializeScreen(levelCompletedPath);

        EventManager.AddGameOverListener(GameOverScreen);
    }

    GameObject InitializeScreen(string pathToScreen)
    {
        GameObject tmp = GameObject.Find(AllScreensPath);

        Transform tmpTransform = tmp.transform.Find(pathToScreen);
        if (tmpTransform != null)
        {
            return tmpTransform.gameObject;
        }
        else
        {
            Debug.LogError(pathToScreen + " not set to the " + AllScreensPath);
            return null;
        }
    }

    public void PauseScreen(InputAction.CallbackContext context)
    {
        if (context.started && !isGameOver)
        {
            RevertPause(pauseScreen);
            AudioManager.Play(pauseSound, pauseSoundVolume);
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

    public void EnemyController(bool addEnemy, int quantity)
    {
        if (addEnemy)
        {
            enemiesQuantity += quantity;
        }
        else
        {
            enemiesQuantity -= quantity;
            if (enemiesQuantity <= 0)
            {
                LevelCompletedScreenTimeOut();
            }
        }
    }

    void LevelCompletedScreen()
    {
        RevertPause(levelCompletedScreen);
    }

    void LevelCompletedScreenTimeOut()
    {
        TimerDelegate timerDelegate = GameObject.FindGameObjectWithTag("TimerDelegate").GetComponent<TimerDelegate>();
        timerDelegate.InitializeTimer(VictoryScreenTimeOut, LevelCompletedScreen);
    }
}
