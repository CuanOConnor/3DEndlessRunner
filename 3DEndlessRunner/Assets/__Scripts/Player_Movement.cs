using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour
{
    public float speed = 10;
    public Rigidbody rb;

    float horizontalInput;
    public float horizontalMultiplier = 1.6f;

    bool alive = true;

    private void FixedUpdate()
    {
        if (!alive)
        {
            return;
        }

        // Player moves forward at a fixed interval
        Vector3 forwardMove = transform.forward * speed * Time.deltaTime;

        // Horizontal movement based on player input
        // Player will move horizontally at the defined factor MORE than the forward speed
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    // Update is called once per frame
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        // Death to gravity
        if (transform.position.y < -5)
        {
            Die();
        }
    }

    public void Die()
    {
        alive = false;
        //restart the game with minor delay for smoothness
        Invoke("Restart", 2);
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
