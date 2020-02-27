/*
    * Jacob Cohen
    * EnemyRunner.cs
    * Assignment #6
    * sets the stats for the enemy runner
*/

using UnityEngine;

public class EnemyRunner : Character
{
    //constructor
    public EnemyRunner()
    {
        //set up stats
        this.health = 2;
        this.speed = 6f;
        this.damage = 1;
        this.friendly = false;
    }

    private void LateUpdate()
    {
        //move towards player
        this.transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }
}