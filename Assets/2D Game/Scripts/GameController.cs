using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int Score;

    public Text scoreText;
    public Text highscoreText;

    private void Start()
    {
        highscoreText.text = "HighScore " + PlayerPrefs.GetInt("HighScore").ToString();
        scoreText.text = "Score " + Score.ToString();
    }

    public void AddScore(int score)
    {
        Score = Score + score;
        scoreText.text = "Score " + Score.ToString();

        int highScore = PlayerPrefs.GetInt("HighScore");
        
        if (Score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", Score);
            highscoreText.text = "HighScore " + PlayerPrefs.GetInt("HighScore").ToString();
        }
    }
}
