using UnityEngine;
using System.Collections.Generic;


public class badGuySpawner : MonoBehaviour 
{
    //variables
    float spawnDelay = .8f;
    private List<Transform> spawners = new List<Transform>();
    

    private void Start()
    {
         //get spawners
        foreach(GameObject item in GameObject.FindGameObjectsWithTag("spawner"))
        {
            spawners.Add(item.transform);
        }

        //loop spawn
        InvokeRepeating("Spawn", spawnDelay, spawnDelay);
    }

    private void Spawn()
    {
        //get spawner
        int spawnIndex = Random.Range(0, spawners.Count);
    }
}