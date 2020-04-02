using UnityEngine;

public class IdleState : FollowerStates 
{
    //variable
    private FollowerController controller;
    private GameObject player;

    private void Awake()
    {
        controller = gameObject.GetComponent<FollowerController>();
        player = controller.playerHolder;
    }

    public override void StartFollowing()
    {
        Debug.Log("Told to follow");

        //set target
        controller.target = player.transform;

        //set state to follow
        controller.currentState = controller.followState;
    }

    public override void StopFollowing()
    {
        Debug.Log("Not following currently");
    }

    public override void CalmDown()
    {
        Debug.Log("Not scared currently");
    }
    public override void Fed()
    {
        Debug.Log("Not tired currently");
    }

    public override void Scared()
    {
        //select random target and run toward it

        //go to scared state
        controller.currentState = controller.scaredState;
    }
}