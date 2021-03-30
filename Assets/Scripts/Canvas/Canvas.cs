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
        scoreText = transform.Find("ScoreText").GetComponent<Text>();
        scoreText.text = "Score: " + score.ToString();

        highScoreText = transform.Find("HighScoreText").GetComponent<Text>();
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    void AddScore(int value)
    {
        score += value;
        scoreText.text = "At Score: " + score.ToString();
    }
}
