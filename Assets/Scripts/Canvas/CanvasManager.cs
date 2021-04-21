using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    Text scoreText;
    Text highScoreText;

    int score = 0;
    int highScore = 0;

    void Awake()
    {
        ResetScore();
        EventManager.AddScoreListener(AddScore);

        scoreText = transform.Find("ScoreText").GetComponent<Text>();
        scoreText.text = "Score: " + score.ToString();

        highScoreText = transform.Find("HighScoreText").GetComponent<Text>();
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    void AddScore(int value)
    {
        score += value;

        if (CheckHighScore())
        {
            highScoreText.text = "High Score: " + highScore.ToString();
        }

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

    bool CheckHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            return true;
        }

        return false;
    }

    void ResetScore()
    {
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetInt("highscore", 0);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetInt("highscore", highScore);
    }
}
