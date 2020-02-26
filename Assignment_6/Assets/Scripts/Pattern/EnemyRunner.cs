/*
    * Jacob Cohen
    * EnemyRunner.cs
    * Assignment #6
    * sets the stats for the enemy runner
*/


public class EnemyRunner : Character
{
    //constructor
    public EnemyRunner()
    {
        this.health = 1;
        this.speed = 6f;
        this.damage = 1;
        this.friendly = false;
    }
}