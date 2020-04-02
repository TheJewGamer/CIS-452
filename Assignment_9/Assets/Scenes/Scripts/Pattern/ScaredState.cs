using UnityEngine;

public class ScaredState : FollowerStates
{
    //variables
    private FollowerController controller;
    private GameObject player;

    private void Awake()
    {
        controller = gameObject.GetComponent<FollowerController>();
        player = controller.playerHolder;
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

        controller.target = this.gameObject.transform;

        //return to idle state
        controller.currentState = controller.idleState;
    }
    public override void Fed()
    {
        Debug.Log("Not tired");
    }

    public override void Scared()
    {
        //select random target and run toward it

        //go to scared state
        controller.currentState = controller.scaredState;
    }
}