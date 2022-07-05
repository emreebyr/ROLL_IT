using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{
    public GameObject[] tileprefabs;
    public float zSpawn = 0;

    [SerializeField]
    public float tileLength = 100;

    public int numberOfTiles = 5;

    private List<GameObject> activeTiles = new List<GameObject>();

    public Transform playerTransform;
    public Transform playerTransform1;
    public Transform playerTransform2;
    public Transform playerTransform3;



    void Start()
    {   
        for(int i=0; i<numberOfTiles ; i++)
        {   
            if (i == 0)
                spawnTile(0);
            else
            spawnTile(Random.Range(0,tileprefabs.Length));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z-50>zSpawn-(numberOfTiles * tileLength))
        {
            spawnTile(Random.Range(0,tileprefabs.Length));
            DeleteTile();
        }

        if(playerTransform1.position.z-50>zSpawn-(numberOfTiles * tileLength))
        {
            spawnTile(Random.Range(0,tileprefabs.Length));
            DeleteTile();
        }

        if(playerTransform2.position.z-50>zSpawn-(numberOfTiles * tileLength))
        {
            spawnTile(Random.Range(0,tileprefabs.Length));
            DeleteTile();
        }
        if(playerTransform3.position.z-50>zSpawn-(numberOfTiles * tileLength))
        {
            spawnTile(Random.Range(0,tileprefabs.Length));
            DeleteTile();
        }
    }

    public void spawnTile (int tileIndex) 
    {
        GameObject go = Instantiate(tileprefabs[tileIndex],transform.forward * zSpawn,transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLength;    
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0],0.5f);
        activeTiles.RemoveAt(0);
    }

    public void DeleteRoads()
    {
        Destroy(activeTiles[5],0.5f);
    }

    
}
