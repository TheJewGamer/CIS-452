/*
    * Jacob Cohen
    * TutYellow.cs
    * Assignment #11
    * controls the yellow pickup in the tutorial
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutYellow : MonoBehaviour
{
    //variables
    private GameObject player;
    private float speed;
    private Vector2 direction;
    private Vector2 bottomLeft;
    private Vector2 topRight;
    private float radius;

    private void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update() 
    {
        //move towards player
        this.gameObject.transform.position = Vector2.MoveTowards(this.gameObject.transform.position, player.transform.position, 3f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
             //call
            player.GetComponent<PlayerController>().StartCoroutine("Stunned");

            //remove gameobject
            Destroy(this.gameObject);
        }    
    }
}
