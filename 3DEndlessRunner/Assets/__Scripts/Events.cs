using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    public void ReplayGame()
    {
        SceneManager.LoadScene("Game");
        GameManager.score = 0; // reset the score
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
