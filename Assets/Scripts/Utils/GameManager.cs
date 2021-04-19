using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

/// <summary>
/// Class which manages the game
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject gameVictoryEffect, gameOverEffect;

    // The highest score obtained by this player
    [Tooltip("The highest score acheived on this device")]
    [SerializeField]
    int highScore = 0;

    [SerializeField]
    bool gameIsWinnable = true;


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

    void Start()
    {

    }

    public void AddScore(int scoreAmount)
    {
        
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
