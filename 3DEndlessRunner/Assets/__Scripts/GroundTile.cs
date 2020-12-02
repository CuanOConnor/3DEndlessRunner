using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;

    [SerializeField] GameObject obstaclePrefab; // allows us to use our obstacle prefab on our tile
    [SerializeField] GameObject coinPrefab; // the coin 

    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>(); // accessing our GroundSpawner script
    }

    // will trigger on an collision
    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 2); // destroy the object after the player leaves (2 seconds)
    }

    public void SpawnObstacle()
    {
        // Choose a random point to spawn the obstacle
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        // spawn the obstacle at the position
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    public void SpawnCoins()
    {
        int coinsToSpawn = 1;

        for (int i = 0; i < coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefab, transform); // spawn the coins
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());// random point spawn call
        }
    }   

    // Using the bounds of the ground tile, decide where the coin is restricted to be spawned
    // Choose a random position in these bounds
    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(                
                Random.Range(collider.bounds.min.x, collider.bounds.max.x),
                Random.Range(collider.bounds.min.y, collider.bounds.max.y),
                Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );

        // makes sure the chosen point is actually ON the collider
        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1; // all spawn on the same height
        return point;
    }
}
