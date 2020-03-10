using UnityEngine;
using System.Collections;

public abstract class Customer : MonoBehaviour
{
    //variables
    private GameObject[] tables;
    private GameObject seatToMoveTo;
    private bool seated;
    private bool ordered;
    private float speed = 2f;

    private void Start() 
    {
        //get tables
        tables = GameObject.FindGameObjectsWithTag("Chair");
        seatToMoveTo = this.gameObject;

        //set vars
        seated = false;
        ordered = false;

        Move();
    }

    private void Update() 
    {
        //check to see if at guard point
        if(Vector2.Distance(this.transform.position, seatToMoveTo.transform.position) < .2f)
        {
            //move towards table
            this.transform.position = Vector2.MoveTowards(this.transform.position, seatToMoveTo.transform.position, speed * Time.deltaTime);

            //look at chair
            this.transform.right = seatToMoveTo.transform.position - transform.position;

            //update var
            seated = false;
        }
        else
        {
            //look at Table
            this.transform.right = seatToMoveTo.transform.GetChild(1).gameObject.transform.position - transform.position;

            //update var
            seated = true;
        }

        //check
        if(seated)
        {
            if(!ordered)
            {
                Order();
            }
            else
            {
                Patience();
            }
        }
    }

    public void Move()
    {
        //find available table
        foreach(GameObject input in tables)
        {
            //check
            if(input.GetComponent<TableController>().inUse == false)
            {
                //in use
                input.GetComponent<TableController>().inUse = true;

                //set var
                seatToMoveTo = input;

                //done
                break;
            }
        }
    }

    public void Leave()
    {
        
    }

    public abstract void Patience();

    public abstract void Order(); 
}