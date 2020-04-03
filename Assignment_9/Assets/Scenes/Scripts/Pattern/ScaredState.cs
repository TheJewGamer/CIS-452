using UnityEngine;

public class ScaredState : FollowerStates
{
    //variables
    private FollowerController controller;
    private GameObject player;

    private void Awake()
    {
        //set up
        controller = gameObject.GetComponent<FollowerController>();
        player = controller.playerHolder;
        controller.scared = true;
    }

    public override void StartFollowing()
    {
        Debug.Log("Currently scared");
    }

    public override void StopFollowing()
    {
        Debug.Log("Not following");
    }

    public override void CalmDown()
    {
        Debug.Log("Told to calm down");

        //update var
        controller.scared = false;

        //return to idle state
        controller.currentState = controller.idleState;
    }
    public override void Fed()
    {
        Debug.Log("Not tired");
    }

    public override void Scared()
    {
        Debug.Log("Already Scared");
    }
}