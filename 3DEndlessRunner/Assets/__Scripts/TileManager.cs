using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs; // an array of our tile prefabs
    private float zSpawn = 0; // position to spawn the tile at
    private float tileLength = 50; // size of the tile
    [SerializeField] int numberOfTiles = 3; // serialized for debugging

    public Transform playerTransform;

    private List<GameObject> activeTiles = new List<GameObject>(); // list of tiles currently active

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            // spawn empty tile first, then spawn a random tile going forward
            if (i == 0)
            {
                SpawnTile(0);
            }
            else
            {
                SpawnTile(Random.Range(0, tilePrefabs.Length));
            }
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        // keep spawning tiles as the player progresses
        if(playerTransform.position.z -35 > zSpawn - (numberOfTiles * tileLength))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
    }

    // Will pop the tile at index 0 off the list and active tiles.
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    // instantiates a tile from the array
    public void SpawnTile(int tileIndex)
    {
        GameObject go = Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go); // tile added to active
        zSpawn += tileLength;
    }
}
