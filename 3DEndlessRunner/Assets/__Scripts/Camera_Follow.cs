using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform player;
    Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        // maintains camera distance from the player
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        // The camera will follow the player, but also stay centered on the track
        Vector3 targetPos = player.position + offset;
        targetPos.x = 0;
        transform.position = targetPos;
    }
}
