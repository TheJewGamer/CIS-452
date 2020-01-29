using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    //variables
    int enemiesPerSpawn = 10;
    float spawnDelay = 1f;
    private List<Transform> spawners = new List<Transform>();
    public GameObject walker; 

    // Start is called before the first frame update
    void Start()
    {
        //get spawners
        foreach(GameObject item in GameObject.FindGameObjectsWithTag("spawner"))
        {
            spawners.Add(item.transform);
        }

        //loop spawn
        InvokeRepeating("SpawnWalker", spawnDelay, spawnDelay);
    }

    void SpawnWalker()
    {
        //get spawner
        int spawnIndex = Random.Range(0, spawners.Count);

        //spawn
        Instantiate(walker, spawners[spawnIndex].position, spawners[spawnIndex].rotation);
    }
}
