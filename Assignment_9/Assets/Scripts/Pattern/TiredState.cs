/*
    * Jacob Cohen
    * TiredState.cs
    * Assignment #9
    * controls the tired state
*/

using UnityEngine;

public class TiredState : FollowerStates 
{
    //variable
    private FollowerController controller;
    private GameObject player;

    private void Start()
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
        controller.target = this.gameObject.transform;

        //return to idle state
        controller.currentState = controller.idleState;

        controller.currentState.Init();
    }

    public override void Scared()
    {
        //go to scared state
        controller.currentState = controller.scaredState;

        //call
        controller.currentState.Init();
    }
    
    public override void Init()
    {
        controller.GetComponent<SpriteRenderer>().sprite = controller.tiredSprite;
    }
}