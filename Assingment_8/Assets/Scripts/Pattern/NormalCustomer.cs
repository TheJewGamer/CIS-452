using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalCustomer : Customer
{
    //variables
    private float waitTime = 20f;
    private float currentWaitTime;
    private string firstOrder;
    private int firstOrderIndex;
    private int secondOrderIndex;
    private string secondOrder;

    private void Start() 
    {
        //set vars
        currentWaitTime = waitTime;

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
        //check
        if(!served)
        {
            //feedback
            this.gameObject.tag = firstOrder;
            this.gameObject.transform.GetChild(firstOrderIndex).gameObject.SetActive(true);        
        }
        //check
        else if(served)
        {
            //feedback
            this.gameObject.tag = "Customer";
            this.gameObject.transform.GetChild(secondOrderIndex).gameObject.SetActive(false);

            //call
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
                //call
                Patience();
            }
        }
    }

    public override void Eat()
    {
        //call
        Debug.Log("eatting");
        StartCoroutine(EatTime());
    }

    public override void Patience()
    {
        //call
        Leave();
    }

    public override void Served()
    {
        //check
        if (!served)
        {
            //update var and call
            Debug.Log("served");
            served = true;
            Order();
            return;
        }
    }

    private IEnumerator EatTime()
    {
        //wait
        yield return new WaitForSeconds(5);

        //done leave
        Debug.Log("leaving");
        Leave();
    }
}
