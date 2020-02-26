/*
    * Jacob Cohen
    * FriendlyRunner.cs
    * Assignment #6
    * sets the stats for a friendly runner
*/

public class FriendlyRunner : Character
{
    //constructor
    public FriendlyRunner()
    {
        this.health = 1;
        this.speed = 2.5f;
        this.damage = 1;
        this.friendly = true;
    }
}