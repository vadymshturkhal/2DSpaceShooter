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
    string thePauseScreenIsHere = "Canvas";
    string pausePathInHierarchy = "PauseScreen";

    [SerializeField]
    GameObject gameVictoryEffect, gameOverEffect;
    GameObject pauseScreen;
    PlayerController controller;

    void Start()
    {
        controller = GetComponent<PlayerController>();

        pauseScreen = GameObject.Find(thePauseScreenIsHere);
        Transform pause = pauseScreen.transform.Find(pausePathInHierarchy);
        if (pause != null)
        {
            pauseScreen = pause.gameObject;
        }
        else
        {
            Debug.LogError("Pause Screen not set to the Game Manager");
        }
    }

    public void PauseScreen(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            RevertPause();
        }
    }

    void RevertPause()
    {
        isPaused = !isPaused;
        controller.paused = isPaused;
        pauseScreen.SetActive(isPaused);

        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("_MainMenu");
        // SceneManager.UnloadSceneAsync("Level1");
    }

    public void ToGame()
    {
        RevertPause();
    }
}
