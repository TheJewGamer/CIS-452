/*
    * Jacob Cohen
    * IdleState.cs
    * Assignment #9
    * controls the idle state
*/

using UnityEngine;

public class IdleState : FollowerStates 
{
    //variable
    private FollowerController controller;
    private GameObject player;

    private void Start()
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

        //call
        controller.currentState.Init();
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
        Debug.Log("Not scared currently");
    }

    public override void Scared()
    {
        Debug.Log("scared");

        //go to scared state
        controller.currentState = controller.scaredState;

        //call
        controller.currentState.Init();
    }

    public override void Init()
    {
        controller.GetComponent<SpriteRenderer>().sprite = controller.normalSprite;
    }
}