/*
    * Jacob Cohen
    * CustomerSpawner.cs
    * Assignment #8
    * Controls the spawning of customers
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public int customersLeft;
    public int customersServed;
    public int waitTimeNormal;
    public int waitTimeCritic;
    public int hardTimeCritic = 5;
    public int hardTimeNormal= 3;
    public int normalTimeCritic = 10;
    public int normalTimeCustomer = 5;
    public Transform spawn;
    public GameObject normalCustomer;
    public GameObject foodCritic;
    public GameObject winMenu;
    public GameObject loseMenu;
    public GameObject difMenu;
    private int currentSpawns;

    // Start is called before the first frame update
    private void Start()
    {
        difMenu.SetActive(true);
        Time.timeScale = 0;
        customersLeft = 0;
        customersServed = 0;
        currentSpawns = 0;
    }

    public void HardDif()
    {
        waitTimeCritic = hardTimeCritic;
        waitTimeNormal = hardTimeNormal;
        difMenu.SetActive(false);
        Time.timeScale = 1;
        StartSpawning();
    }
    
    public void NormalDif()
    {
        waitTimeCritic = normalTimeCritic;
        waitTimeNormal = normalTimeCustomer;
        difMenu.SetActive(false);
        Time.timeScale = 1;
        StartSpawning();
    }

    // Update is called once per frame
    private void StartSpawning()
    {
        InvokeRepeating("SpawnNormalCustomer",waitTimeNormal,waitTimeNormal);
        InvokeRepeating("SpawnFoodCritic", waitTimeCritic,waitTimeCritic);
    }

    private void SpawnNormalCustomer()
    {
        //check
        if(currentSpawns >= 15)
        {
            StopAllCoroutines();
            CancelInvoke();
        }


        //spawn
        Instantiate(normalCustomer, spawn.position, spawn.rotation);

        //inc
        currentSpawns++;
    }

    private void SpawnFoodCritic()
    {
        //check
        if(currentSpawns >= 15)
        {
            StopAllCoroutines();
            CancelInvoke();
        }

        //spawn
        Instantiate(foodCritic, spawn.position, spawn.rotation);

        //inc
        currentSpawns++;
    }

    public void StateCheck()
    {
        //win check
        if(customersServed >= 3)
        {
            //stop game
            Time.timeScale = 0;

            //stop
            CancelInvoke();
            StopAllCoroutines();

            //open menu
            winMenu.SetActive(true);
        }
        //lose check
        else if(customersLeft >= 3)
        {
            //stop game
            Time.timeScale = 0;
            CancelInvoke();
            StopAllCoroutines();

            //open menu
            loseMenu.SetActive(true);
        }
    }
}
