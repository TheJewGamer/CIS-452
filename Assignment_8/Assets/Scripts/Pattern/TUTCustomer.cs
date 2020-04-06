/*
    * Jacob Cohen
    * TUTCustomer.cs
    * Assignment #8
    * controls the customer used in the tutorial
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TUTCustomer : Customer
{
   //variables
    private float waitTime = 60f;
    private float currentWaitTime;
    private string firstOrder;
    private int firstOrderIndex;
    public bool firstServed;

    private void Start() 
    {
        //set vars
        currentWaitTime = waitTime;   
        firstServed = false;

        //get 2 random food option
        firstOrderIndex = Random.Range(0,foodOptions.Length);
        firstOrder = foodOptions[firstOrderIndex];

        //call
        CustomerStart();
    }

    public override void Order()
    {
        //check
        if(!firstServed)
        {
            this.gameObject.tag = firstOrder;
            this.gameObject.transform.GetChild(firstOrderIndex).gameObject.SetActive(true);        
        }
        else if(firstServed)
        {
            this.gameObject.tag = "Customer";
            this.gameObject.transform.GetChild(firstOrderIndex).gameObject.SetActive(false);
            this.served = true;
            Eat();
        }
    }

    public override void Eat()
    {
        //call
        seatToMoveTo.transform.GetChild(1).gameObject.SetActive(true);
        StartCoroutine(EatTime());
    }

    public override void Patience()
    {
        //served
        manager.customersLeft++;
        manager.StateCheck();
        this.leaving = true;
    }

    public override void Served()
    {
        if (!firstServed)
        {
            firstServed = true;
            Order();
            return;
        }
        else if (firstServed)
        {
            Order();
        }
    }

    private IEnumerator EatTime()
    {
        yield return new WaitForSeconds(5);

        //served
        manager.customersServed++;
        manager.StateCheck();

        //done
        this.leaving = true;
    }
}
