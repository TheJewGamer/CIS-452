/*
    * Jacob Cohen
    * Customer.cs
    * Assignment #8
    * main class for the pattern
*/

using UnityEngine;
using System.Collections;

public abstract class Customer : MonoBehaviour
{
    //variables
    private GameObject[] tables;
    protected string[] foodOptions = { "wantsBlue", "wantsGreen", "wantsPink"};
    protected GameObject seatToMoveTo;
    public bool seated;
    private bool ordered;
    private float speed = 2f;
    public bool served;
    protected bool leaving;
    private Transform spawn;
    private GameObject exit;
    protected CustomerSpawner manager;

    protected void CustomerStart() 
    {   
        //get tables
        tables = GameObject.FindGameObjectsWithTag("Chair");
        seatToMoveTo = null;

        //set vars
        seated = false;
        ordered = false;
        served = false;
        leaving = false;

        //get items
        exit = GameObject.Find("exit");
        manager = GameObject.Find("Scripts").GetComponent<CustomerSpawner>();

        //call
        Move();
    }

    private void Update() 
    {
        if(seatToMoveTo != null && Vector2.Distance(this.gameObject.transform.position, seatToMoveTo.transform.position) > .2f && !leaving)
        {
            //move towards table
            this.gameObject.transform.position = Vector2.MoveTowards(this.gameObject.transform.position, seatToMoveTo.transform.position, speed * Time.deltaTime);

            //look at chair
            this.gameObject.transform.right = seatToMoveTo.transform.position - transform.position;
        }
        else if(seatToMoveTo != null)
        {
            seated = true;
        }

        //check
        if(seated)
        {
            //check
            if(!ordered)
            {
                //order food
                ordered = true;
                Order();
            }
        }

        if(leaving)
        {
            Leave();
        }
    }

    public void Move()
    {
        //find available table
        foreach(GameObject input in tables)
        {
            //check
            if(input.gameObject.GetComponent<TableController>().inUse == false)
            {
                //in use
                input.GetComponent<TableController>().inUse = true;

                //set var
                seatToMoveTo = input;

                //done
                return;
            }
        }
            //look at Table
            this.gameObject.transform.right = seatToMoveTo.transform.GetChild(0).gameObject.transform.position - transform.position;
    }

    public void Leave()
    {
        //seat is empty
        seatToMoveTo.GetComponent<TableController>().inUse = false;
        seatToMoveTo.transform.GetChild(1).gameObject.SetActive(false);

        //remove tag
        this.gameObject.tag = "Customer";

        //hide all food options
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        this.gameObject.transform.GetChild(2).gameObject.SetActive(false);

        //move towards exit
        this.transform.position = Vector2.MoveTowards(this.transform.position, exit.transform.position, speed * Time.deltaTime);

        //look at exit
        this.transform.right = exit.transform.position - transform.position;
        
        if(Vector2.Distance(this.gameObject.transform.position, exit.transform.position) < .2f)
        {
            Destroy(this.gameObject);
        }
    }

    public abstract void Patience();
    public abstract void Served();
    public abstract void Order();
    public abstract void Eat();
}