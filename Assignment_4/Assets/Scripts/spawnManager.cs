/*
    * Jacob Cohen
    * goalManager.cs
    * Assignment #4
    * controls the spawning of enemies
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    //variables
    float spawnDelay = .8f;
    private List<Transform> spawners = new List<Transform>();
    public GameObject enemy; 

    // Start is called before the first frame update
    public void Start()
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

        //spawn
        Instantiate(enemy, spawners[spawnIndex].position, spawners[spawnIndex].rotation);
    }
}
