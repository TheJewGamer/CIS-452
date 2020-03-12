using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCritic : Customer
{
    private float waitTime = 20f;
    private float currentWaitTime;
    private string firstOrder;
    private int firstOrderIndex;
    private int secondOrderIndex;
    private string secondOrder;
    public bool firstServed;
    public bool secondServed;

    private void Start() 
    {
        //set vars
        currentWaitTime = waitTime;   
        firstServed = false;
        secondServed = false;

        //get 2 random food option
        firstOrderIndex = Random.Range(0,foodOptions.Length);
        firstOrder = foodOptions[firstOrderIndex];

        secondOrderIndex = Random.Range(0,foodOptions.Length);
        secondOrder = foodOptions[secondOrderIndex];

        //call
        CustomerStart();
    }

    public override void Order()
    {
        Debug.Log("ordered");
        //check
        if(!firstServed)
        {
            Debug.Log("order first");
            this.gameObject.tag = firstOrder;
            this.gameObject.transform.GetChild(firstOrderIndex).gameObject.SetActive(true);        
        }
        else if(firstServed && !secondServed)
        {
            this.gameObject.tag = secondOrder;
            this.gameObject.transform.GetChild(firstOrderIndex).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(secondOrderIndex).gameObject.SetActive(true);

            //reset wait time
            currentWaitTime = waitTime;
        }
        else if(firstServed && secondServed)
        {
            this.gameObject.tag = "Customer";
            this.gameObject.transform.GetChild(secondOrderIndex).gameObject.SetActive(false);
            this.served = true;
            Eat();
        }
        
    }


    private void LateUpdate() 
    {
        //check
        if(!this.served && this.seated)
        {
            //check
            if(waitTime <= 0)
            {
                //wait
                waitTime -= Time.deltaTime;
            }
            else
            {
                //Patience();
            }
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
        //call
        Leave();
    }

    public override void Served()
    {
        if (!firstServed)
        {
            Debug.Log("First served");
            firstServed = true;
            Order();
            return;
        }
        else if (firstServed && !secondServed)
        {
            Debug.Log("Second served");
            secondServed = true;
            Order();
        }
    }

    private IEnumerator EatTime()
    {
        yield return new WaitForSeconds(5);

        //done
        Debug.Log("leaving");
        Leave();
    }
}
