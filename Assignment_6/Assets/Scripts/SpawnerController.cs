/*
    * Jacob Cohen
    * SpawnerController.cs
    * Assignment #6
    * controls the spawing of the characters
*/

using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    //vars
    private float spawnDelay = 2f;
    private List<Transform> spawners = new List<Transform>();
    private GameObject currentCharacterSpawn;
    private string[] enemyTypeArray = new string[]
    {
        "walker",
        "runner"
    };
    private GameObject player;

    //pattern
    private CharacterCreator characterCreator;

    // Start is called before the first frame update
    private void Start()
    {
        //get player
        player = GameObject.FindGameObjectWithTag("Player");

        //get spawners
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Spawner"))
        {
            spawners.Add(item.transform);
        }

        //loop spawn
        InvokeRepeating("SpawnEnemy", spawnDelay, spawnDelay);
    }

    private void LateUpdate() 
    {
        //input for friendly spawns
        if(Input.GetKeyDown(KeyCode.Alpha1) == true)
        {
            //check to see if player has enough points
            if(player.GetComponent<PlayerController>().specialAmmo >= 3)
            {
                //dec points
                player.GetComponent<PlayerController>().specialAmmo -= 3;

                characterCreator = new FriendlyCharacter();

                currentCharacterSpawn = characterCreator.CreateCharacter("walker");

                //spawn walker
                currentCharacterSpawn = Instantiate(currentCharacterSpawn, player.transform.position, player.transform.rotation);

                //add walker script
                currentCharacterSpawn.AddComponent<FriendlyWalker>();

                //make friendly
                currentCharacterSpawn.GetComponent<Character>().friendly = true;
            }
        }    

        if(Input.GetKeyDown(KeyCode.Alpha2) == true)
        {
            //check to see if player has enough points
            if(player.GetComponent<PlayerController>().specialAmmo >= 5)
            {
                //dec points
                player.GetComponent<PlayerController>().specialAmmo -= 5;

                characterCreator = new FriendlyCharacter();

                currentCharacterSpawn = characterCreator.CreateCharacter("runner");

                //spawn runner
                currentCharacterSpawn = Instantiate(currentCharacterSpawn, player.transform.position, player.transform.rotation);

                //add runner script
                currentCharacterSpawn.AddComponent<FriendlyRunner>();

                //make friendly
                currentCharacterSpawn.GetComponent<Character>().friendly = true;
            }
        }
    }

    private void SpawnEnemy()
    {
        characterCreator = new EnemyCharacter();

        //get spawn point
        int spawnIndex = Random.Range(0, spawners.Count);

        //get enemy type
        string enemyType = enemyTypeArray[Random.Range(0, enemyTypeArray.Length)];

        //get character
        currentCharacterSpawn = characterCreator.CreateCharacter(enemyType);

        //spawn character
        currentCharacterSpawn = Instantiate(currentCharacterSpawn, spawners[spawnIndex].position, spawners[spawnIndex].rotation);

        //add script
        if(enemyType == "walker")
        {
            //add walker script
            currentCharacterSpawn.AddComponent<EnemyWalker>();
        }
        else
        {
            //add runner script
            currentCharacterSpawn.AddComponent<EnemyRunner>();
        }
    }

    private void SpawnFriendly()
    {
        characterCreator = new EnemyCharacter();
    }

}
