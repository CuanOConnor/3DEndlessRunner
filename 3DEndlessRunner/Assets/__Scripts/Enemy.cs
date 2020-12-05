using UnityEngine;

public class Enemy : MonoBehaviour
{
    Player_Movement player_Movement; // player class

   
    public float speed = 1.0f;

    void Start()
    {
        player_Movement = GameObject.FindObjectOfType<Player_Movement>();
    }

    private void Update()
    {
        Vector3 pos1 = new Vector3(-4, transform.position.y, transform.position.z);
        Vector3 pos2 = new Vector3(4, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
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