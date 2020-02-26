/*
    * Jacob Cohen
    * EnemyWalker.cs
    * Assignment #6
    * sets up the stats for the enemy walker
*/

public class EnemyWalker : Character
{
    //constructor
    public EnemyWalker()
    {
        this.health = 3;
        this.speed = 1.5f;
        this.damage = 2;
        this.friendly = false;
    }
}