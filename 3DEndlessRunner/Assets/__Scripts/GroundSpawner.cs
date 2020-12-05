using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject groundTile;
    Vector3 nextSpawnPoint;

    public void SpawnTile(bool spawnItems)
    {
        // spawning tile, at our desired location and its rotation
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;

        // check if we want to spawn objects on the tile 
        //(initially we want the player to travel on empty tiles)
        if (spawnItems)
        {
            temp.GetComponent<GroundTile>().SpawnObstacle();
            temp.GetComponent<GroundTile>().SpawnCoins();
            temp.GetComponent<GroundTile>().SpawnEnemy();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            // dont spawn objects on the tile until 3 have spawned first
            if (i < 3)
            {
                SpawnTile(false);
            }
            else 
            {
                SpawnTile(true);
            }
            
        }
    }

}
