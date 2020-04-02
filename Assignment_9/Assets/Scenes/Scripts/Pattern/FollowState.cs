using UnityEngine;
using System.Collections;

public class FollowState : FollowerStates 
{
    //variable
    private FollowerController controller;
    public GameObject player;

    private void Awake()
    {
        controller = gameObject.GetComponent<FollowerController>();
        player = controller.playerHolder;
        StartCoroutine(TiredTimer());
    }

    public override void StartFollowing()
    {
        Debug.Log("Already following the player");
    }

    public override void StopFollowing()
    {
        Debug.Log("Stop following the player");

        //stop timer
        StopAllCoroutines();
        
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
        //select random target and run toward it

        //go to scared state
        controller.currentState = controller.scaredState;
    }

    private IEnumerator TiredTimer()
    {
        Debug.Log("timer");

        yield return new WaitForSeconds(5);

        //switch target
        controller.target = gameObject.transform;

        //switch to tired state
        controller.currentState = controller.tiredState;
        
    }
}