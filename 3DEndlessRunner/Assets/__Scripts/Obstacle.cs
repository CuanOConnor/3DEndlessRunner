using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Player_Movement player_Movement; // player class


    // Start is called before the first frame update
    void Start()
    {
        player_Movement = GameObject.FindObjectOfType<Player_Movement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // check for the player colliding
        if (collision.gameObject.name == "Player")
        {
            player_Movement.Die();
        }
        // Damage/Kill player

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
