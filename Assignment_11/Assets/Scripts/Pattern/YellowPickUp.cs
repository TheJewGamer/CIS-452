/*
    * Jacob Cohen
    * YellowPickUp.cs
    * Assignment #11
    * controls the yellow pickup
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPickUp : MonoBehaviour
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
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0,0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        radius = transform.localScale.x / 2;
        direction = Vector2.one.normalized;
        speed = 1;
    }

    public void PickedUp(PickUpManager manager)
    {
        //call
        player.GetComponent<PlayerController>().StartCoroutine("Stunned");

        //remove gameobject
        Destroy(this.gameObject);
    }
    
    public void Action()
    {
        //move
        transform.Translate(direction * speed * Time.deltaTime);

        //up down
        if(transform.position.y < bottomLeft.y + radius && direction.y < 0)
        {
            direction.y = -direction.y;
        }
        if(transform.position.y > topRight.y + radius && direction.y > 0)
        {
            direction.y = -direction.y;
        }

        //left right
        if(transform.position.x < bottomLeft.x + radius && direction.x < 0)
        {
            direction.x = -direction.x;
        }
        if(transform.position.x > topRight.x + radius && direction.x> 0)
        {
            direction.x = -direction.x;
        }
        
    }
}
