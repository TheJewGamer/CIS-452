/*
    * Jacob Cohen
    * FriendlyWalker.cs
    * Assignment #6
    * sets the stats for a friendly walker
*/

public class FriendlyWalker : Character
{
    //constructor
    public FriendlyWalker()
    {
        this.health = 3;
        this.speed = 3f;
        this.damage = 2;
        this.friendly = true;
    }
}