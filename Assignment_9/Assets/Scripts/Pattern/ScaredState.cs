/*
    * Jacob Cohen
    * ScaredState.cs
    * Assignment #9
    * controls the Scared state
*/

using UnityEngine;

public class ScaredState : FollowerStates
{
    //variables
    private FollowerController controller;
    private GameObject player;

    private void Start()
    {
        //set up
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

        //update var
        controller.scared = false;

        //return to idle state
        controller.currentState = controller.idleState;

        //call
        controller.currentState.Init();
    }
    public override void Fed()
    {
        Debug.Log("Not tired");
    }

    public override void Scared()
    {
        Debug.Log("Already Scared");
    }

    public override void Init()
    {
        controller.scared = true;
        controller.gameObject.GetComponent<SpriteRenderer>().sprite = controller.scaredSprite;
        StopAllCoroutines();
    }
}