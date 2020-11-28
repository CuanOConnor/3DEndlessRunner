using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;

    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>(); // accessing our GroundSpawner script
    }

    // will trigger on an collision
    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2); // destroy the object after the player leaves (2 seconds)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
