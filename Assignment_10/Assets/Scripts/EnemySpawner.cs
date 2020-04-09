/*
    * Jacob Cohen
    * EnemySpawner.cs
    * Assignment #10
    * controls the spawning of enemies
*/

using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour 
{
    //variable
    private ObjectPool objectPooler;
    private string[] enemyType = {"Runner", "Walker"};
    public Transform[] spawnerLocations;

    private void Start() 
    {
        //set up
        objectPooler = ObjectPool.instance;

        //loop
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {

        //get spawn location
        Transform spawner = spawnerLocations[Random.Range(0,spawnerLocations.Length)];

        //get spawn type
        string type = enemyType[Random.Range(0,2)];

        //wait
        yield return new WaitForSeconds(3);

        //spawn
        objectPooler.Spawn(type, spawner.position);

        //repeat
        StartCoroutine(Spawner());
    }
}