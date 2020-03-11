using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CustomerController : MonoBehaviour 
{
    private GameObject normalCustomer;
    private GameObject foodCritic;
    public Transform spawner;
    private GameObject currentSpawn;
    private GameObject[] tables;
    private GameObject seatToMoveTo;
    private bool seated;
    private bool ordered;
    private float speed = 2f;

    NormalCustomer normal;
    FoodCritic critic;

    private void Start() 
    {
        normal = new NormalCustomer();
        critic = new FoodCritic();

        //get tables
        tables = GameObject.FindGameObjectsWithTag("Chair");

        //set vars
        seatToMoveTo = null;
    } 

    private void Update() 
    {
        //spawn
        currentSpawn = Instantiate(normalCustomer, spawner.position, spawner.rotation);

        //check to see if at table point
        if(Vector2.Distance(currentSpawn.transform.position, seatToMoveTo.transform.position) < .2f)
        {
            //move towards table
            currentSpawn.transform.position = Vector2.MoveTowards(this.transform.position, seatToMoveTo.transform.position, speed * Time.deltaTime);

            //look at chair
            currentSpawn.transform.right = seatToMoveTo.transform.position - transform.position;

            //update var
            normal.seated = false;
        }
        else
        {
            //look at Table
            currentSpawn.transform.right = seatToMoveTo.transform.GetChild(0).gameObject.transform.position - transform.position;

            //update var
            seated = true;
        }

        //check
        if(seated)
        {
            if(!ordered)
            {
                //Order();
            }
            else
            {
               // Patience();
            }
        }
    }

    private GameObject GetTable()
    {
        //find available table
        foreach(GameObject input in tables)
        {
            //check
            if(input.GetComponent<TableController>().inUse == false)
            {
                //in use
                input.GetComponent<TableController>().inUse = true;

                //done
                return input;
            }
        }

        //error
        return null;
    }
}