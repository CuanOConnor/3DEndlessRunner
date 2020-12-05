using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Player_Movement player_Movement; // player class

    void Start()
    {
        player_Movement = GameObject.FindObjectOfType<Player_Movement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // check for the player colliding
        if (collision.gameObject.name == "Player")
        {
            // Damage/Kill player
            player_Movement.Die();
        }   
    }
}
