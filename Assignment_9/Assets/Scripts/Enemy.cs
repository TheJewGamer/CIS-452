/*
    * Jacob Cohen
    * Enemy.cs
    * Assignment #9
    * controls the enemies in the game level
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //variable
    private GameObject follower;
    private float speed = .15f;

    // Start is called before the first frame update
    void Start()
    {
        follower = GameObject.FindWithTag("Follower");
    }

    // Update is called once per frame
    void Update()
    {
        //check to see if close to follower
        if(Vector2.Distance(follower.transform.position, transform.transform.position) < .5f)
        {
            //check to see if already scared
            if(follower.GetComponent<FollowerController>().scared == false)
            {
                //call
                follower.GetComponent<FollowerController>().NearEnemy();
            }

            //move towards follower
            this.gameObject.transform.position = Vector2.MoveTowards(this.gameObject.transform.position, follower.transform.position, speed * Time.deltaTime);

            //look at follower
            this.gameObject.transform.right = follower.transform.position - transform.position;
        }        
    }

    public void OnTriggerEnter2D(Collider2D other) 
    {
        //check to see if player
        if(other.gameObject.tag == "Player")
        {
            //dead
            Destroy(this.gameObject);
        }    
    }
}
