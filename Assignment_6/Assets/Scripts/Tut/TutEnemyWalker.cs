/*
    * Jacob Cohen
    * TutEnemyWalker.cs
    * Assignment #6
    * sets up the stats for the tut enemy walker
*/

using UnityEngine;

public class TutEnemyWalker : Character
{
    private GameObject target;

    //constructor
    public TutEnemyWalker()
    {
        //set up stats 
        this.health = 3;
        this.speed = 3f;
        this.damage = 2;
        this.friendly = false;
    }

    private void Awake() 
    {
        //get target
        target = GameObject.Find("TargetEnemy");
    }

    private void LateUpdate()
    {
        //move towards player
        this.transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, speed * Time.deltaTime);
    }
}