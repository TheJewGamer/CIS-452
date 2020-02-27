/*
    * Jacob Cohen
    * TutRunnerFriendly.cs
    * Assignment #6
    * sets up the stats of the tut friendly walker
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutWalkerFriendly : Character
{
    //var
    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        //set up stats 
        this.health = 3;
        this.speed = 3f;
        this.damage = 2;
        this.friendly = true;

        //get position
        target = GameObject.Find("TargetFriendly").gameObject.transform;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        //move towards player
        this.transform.position = Vector2.MoveTowards(this.transform.position, target.position, speed * Time.deltaTime);
    }
}
