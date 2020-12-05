using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction; // player move
    [SerializeField] float forwardSpeed = 5f;

    private int desiredLane = 1;// 0: left 1:middle 2:right
    public float laneDistance = 3; // distance between two lanes

    [SerializeField] float jumpForce = 6f;
    [SerializeField] float gravity = -20;

    private void Start()
    {
        controller = GetComponent<CharacterController>(); //controller component
    }

    private void Update()
    {
        controller.Move(direction * Time.fixedDeltaTime); // move character

        direction.z = forwardSpeed; // player moves on the z axis

        // check if the player is grounded, then prevent jump if in the air
        if (controller.isGrounded)
        {
            direction.y = -1;

            //Implementing jump
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
        else
        {
            direction.y += gravity * Time.deltaTime; // player affected by gravity
        }

        // Gather inputs to determine desired lane
        // increments desiredLane to determine our position
        if (Input.GetKeyDown(KeyCode.D))
        {
            desiredLane++;
            // prevent value out of bounds
            if(desiredLane == 3)
            {
                desiredLane = 2;
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            desiredLane--;
            // prevent value out of bounds
            if (desiredLane == -1)
            {
                desiredLane = 0;
            }
        }

        // Calculate where we should be in the future
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if(desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if(desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, 80 *Time.deltaTime); //Lerp adds smoothness to the transitions between lanes.
        controller.center = controller.center;// hacky fix for a collision error (note: likely occured due to changing transform positions but not sure)
    }

    private void Jump()
    {
        direction.y = jumpForce; // travel up
    }

    // call when player controller collides
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // check if collision with obstacle
        if (hit.transform.tag == "Obstacle")
        {
            GameManager.gameOver = true;
        }
    }
}
