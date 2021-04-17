using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas : MonoBehaviour
{
    AddScoreEvent addScoreEvent;
    Text scoreText;
    Text highScoreText;

    int score = 0;
    int highScore = 0;

    void Awake()
    {
        EventManager.AddScoreListener(AddScore);
    }

    void Start()
    {
        CheckScore();

        scoreText = transform.Find("ScoreText").GetComponent<Text>();
        scoreText.text = "Score: " + score.ToString();

        highScoreText = transform.Find("HighScoreText").GetComponent<Text>();
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    void AddScore(int value)
    {
        score += value;
        PlayerPrefs.SetInt("score", score);
        scoreText.text = "Score: " + score.ToString();
    }

    void CheckScore()
    {
        if (PlayerPrefs.HasKey("highscore"))
        {
            highScore = PlayerPrefs.GetInt("highscore");
        }
        else
        {
            PlayerPrefs.SetInt("highscore", 0);
        }

        if (PlayerPrefs.HasKey("score"))
        {
            score = PlayerPrefs.GetInt("score");
        }
        else
        {
            PlayerPrefs.SetInt("score", 0);
        }
    }

    private void OnApplicationQuit()
    {
        if (score > highScore)
        {
            highScore = score;
        }

        PlayerPrefs.SetInt("highscore", highScore);
        PlayerPrefs.SetInt("score", 0);
    }
}
