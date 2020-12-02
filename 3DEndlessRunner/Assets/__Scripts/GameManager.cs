using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int score;
    public static GameManager inst;

    [SerializeField] Text scoreText;
    [SerializeField] Player_Movement player_Movement;

    public void IncrementScore()
    {
        score += 10;
        scoreText.text = "SCORE: " + score;

        // increase the players speed
        player_Movement.speed += player_Movement.speedIncreasePerPoint;
    }

    public void Awake()
    {
        inst = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
