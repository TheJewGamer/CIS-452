/*
    * Jacob Cohen
    * EnemyWalker.cs
    * Assignment #6
    * sets up the stats for the enemy walker
*/

using UnityEngine;

public class EnemyWalker : Character
{
    //constructor
    public EnemyWalker()
    {
        //set up stats 
        this.health = 3;
        this.speed = 3f;
        this.damage = 2;
        this.friendly = false;
    }

    private void LateUpdate()
    {
        //move towards player
        this.transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }
}