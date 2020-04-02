using UnityEngine;

public class TiredState : FollowerStates 
{
    //variable
    private FollowerController controller;
    private GameObject player;

    private void Awake()
    {
        //get player script
        controller = gameObject.GetComponent<FollowerController>();
        player = controller.playerHolder;
    }

    public override void StartFollowing()
    {
        Debug.Log("Currently tired");
    }

    public override void StopFollowing()
    {
        Debug.Log("Not following");
    }

    public override void CalmDown()
    {
        Debug.Log("Not scared");
    }
    public override void Fed()
    {
        Debug.Log("Not tired anymore");

        controller.target = this.gameObject.transform;

        //return to idle state
        controller.currentState = controller.idleState;
    }

    public override void Scared()
    {
        //select random target and run toward it

        //go to scared state
        controller.currentState = controller.scaredState;
    }
}