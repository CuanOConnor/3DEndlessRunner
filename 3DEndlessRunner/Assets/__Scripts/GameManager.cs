using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;

    public static int score = 0;

    public Text scoreText;
    public Text highScore;

    private void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0; // pause the game
            gameOverPanel.SetActive(true); // display game over UI
        }

        scoreText.text = "Score: " + score;

        // System for storing and displaying a highscore within the game
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

        highScore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
}
