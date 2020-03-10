using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalCustomer : Customer
{
    private float waitTime = 5f;
    private float currentWaitTime;

    private void Start() 
    {
        currentWaitTime = waitTime;     
    }

    public override void Order()
    {
        //get random food option

        
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
}
