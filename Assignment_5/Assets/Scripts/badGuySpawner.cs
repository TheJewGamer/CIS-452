/*
    * Jacob Cohen
    * badGuySpawner.cs
    * Assignment #5
    * controls the spawnning of badguys
*/

using UnityEngine;
using System.Collections.Generic;

public class badGuySpawner : MonoBehaviour 
{
    //variables
    float spawnDelay = 1.5f;
    private List<Transform> spawners = new List<Transform>();
    public GameObject badGuyPreFab;
    private GameObject badGuyCurrentSpawn;
    public BadGuyFactory factory;
    private string[] badGuyTypes = new string[]
    {
        "walker",
        "runner",
        "heavy"
    };
    

    private void Start()
    {
         //get spawners
        foreach(GameObject item in GameObject.FindGameObjectsWithTag("spawnpoint"))
        {
            spawners.Add(item.transform);
        }

        //loop spawn
        InvokeRepeating("Spawn", spawnDelay, spawnDelay);
    }

    private void Spawn()
    {
        //get spawn point
        int spawnIndex = Random.Range(0, spawners.Count);

        //get badguy type
        string badGuyType = badGuyTypes[Random.Range(0, badGuyTypes.Length)];

        //spawn
        badGuyCurrentSpawn = Instantiate(badGuyPreFab, spawners[spawnIndex].position, spawners[spawnIndex].rotation);

        //call and set bad guy type
        badGuyCurrentSpawn = factory.CreateBadGuy(badGuyType,badGuyCurrentSpawn);
    }
}