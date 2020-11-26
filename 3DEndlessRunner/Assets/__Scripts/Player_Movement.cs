using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody rb;

    float horizontalInput;
    public float horizontalMultiplier = 2;

    private void FixedUpdate()
    {
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
    }
}
