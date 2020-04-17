/*
    * Jacob Cohen
    * RedPickup.cs
    * Assignment #11
    * controls the red pickup
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPickup : MonoBehaviour
{
    //variables
    private GameObject player;

    private void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void PickedUp(PickUpManager manager)
    {
        //subtract points
        manager.livesLeft--;

        //remove gameobject
        Destroy(this.gameObject);
    }
    
    public void Action()
    {
        //move towards player
        this.gameObject.transform.position = Vector2.MoveTowards(this.gameObject.transform.position, player.transform.position, .5f * Time.deltaTime);

        //look at player
        this.gameObject.transform.up = player.transform.position - transform.position;
    }
}
