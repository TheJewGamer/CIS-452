using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    //vars
    private float spawnDelay;
    private List<Transform> spawners = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        //get spawners
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("spawnpoint"))
        {
            spawners.Add(item.transform);
        }

        //loop spawn
        InvokeRepeating("SpawnEnemy", spawnDelay, spawnDelay);
    }

    private void SpawnEnemy()
    {
        //get spawn point
        int spawnIndex = Random.Range(0, spawners.Count);

        //get badguy type
        string badGuyType = badGuyTypes[Random.Range(0, badGuyTypes.Length)];

        //spawn
        badGuyCurrentSpawn = Instantiate(badGuyPreFab, spawners[spawnIndex].position, spawners[spawnIndex].rotation);

        //call and set bad guy type
        badGuyCurrentSpawn = factory.CreateBadGuy(badGuyType, badGuyCurrentSpawn);
    }

    private void SpawnFriendly()
    {

    }

}
