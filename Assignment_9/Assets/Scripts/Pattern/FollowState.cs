/*
    * Jacob Cohen
    * FollowState.cs
    * Assignment #9
    * Controls the follow state
*/

using UnityEngine;

public class FollowState : FollowerStates 
{
    //variable
    private FollowerController controller;
    public GameObject player;
    private float waitTime = 5f;
    private float currentWaitTime;
    

    private void Start()
    {
        controller = gameObject.GetComponent<FollowerController>();
        player = controller.playerHolder;
        currentWaitTime = waitTime;
    }

    public override void StartFollowing()
    {
        Debug.Log("Already following the player");
    }

    public override void StopFollowing()
    {
        Debug.Log("Stop following the player");
        
        //set target
        controller.target = this.gameObject.transform;

        //return to idle state
        controller.currentState = controller.idleState;
    }

    public override void CalmDown()
    {
       Debug.Log("Currently following the player, is not scared");
    }
    public override void Fed()
    {
        Debug.Log("Currently following the player, is not tired");
    }

    public override void Scared()
    {
        Debug.Log("Scared");

        controller.target = this.gameObject.transform;

        //go to scared state
        controller.currentState = controller.scaredState;

        //call
        controller.currentState.Init();
    }

    public override void Init()
    {
        controller.GetComponent<SpriteRenderer>().sprite = controller.normalSprite;
        currentWaitTime = waitTime;
    }

    private void LateUpdate() 
    {
        //check to see if current state
        if(controller.currentState == this)
        {
            //check
            if(currentWaitTime >= 0)
            {
                //wait
                currentWaitTime -= Time.deltaTime;
            }
            else
            {
                //switch target
                controller.target = gameObject.transform;

                //switch to tired state
                controller.currentState = controller.tiredState;

                //call
                controller.currentState.Init();
            } 
        }
           
    }

}