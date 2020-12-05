using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;

    private void Start()
    {
        gameOver = false;
    }

    private void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0; // pause the game
            gameOverPanel.SetActive(true); // display game over UI
        }
    }
}
