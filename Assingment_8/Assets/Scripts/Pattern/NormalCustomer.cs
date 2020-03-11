using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalCustomer : Customer
{
    private float waitTime = 10f;
    private float currentWaitTime;

    private void Start() 
    {
        currentWaitTime = waitTime;     
    }

    public override void Order()
    {
        //get 1 random food option
        
        
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
