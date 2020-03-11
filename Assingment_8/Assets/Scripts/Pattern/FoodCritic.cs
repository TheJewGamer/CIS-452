using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCritic : Customer
{
    private float waitTime = 5f;
    private float currentWaitTime;

    private void Start() 
    {
        currentWaitTime = waitTime;     
    }

    public override void Order()
    {
        //get 2 random food option
        
        
    }

    public override void Patience()
    {
        if(waitTime <= 0)
        {
            //leave
            Leave();
        }
        else
        {
            //wait
            waitTime -= Time.deltaTime;
        }
    }

    public override void Eat()
    {
        
    }
}
