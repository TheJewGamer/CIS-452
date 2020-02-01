/*
    * Jacob Cohen
    * MovementBehavior.cs
    * Assignment #2
    * Controls the movement of the enemy blobs implemented using a Strategy Pattern
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementWalk : MovementBehavior
{
    public override void Move(GameObject player)
    {
        //move towards player
        this.transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, .25f * Time.deltaTime);

        //look at player
        this.transform.right = (player.transform.position - transform.position) * -1;
    }
}

public class MovementRun : MovementBehavior
{
    public override void Move(GameObject player)
    {
        //change sprite
        GetComponent<SpriteRenderer>().sprite = GameObject.Find("runnerSprite").GetComponent<SpriteRenderer>().sprite;

        //move towards player
        this.transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, .5f * Time.deltaTime);

        //look at player
        this.transform.right = (player.transform.position - transform.position) * -1;
    }
}