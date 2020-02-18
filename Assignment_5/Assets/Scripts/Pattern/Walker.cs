/*
    * Jacob Cohen
    * Walker.cs
    * Assignment #5
    * sets the walker's stats
*/
public class Walker : BadGuy 
{
    //constructor
    public Walker()
    {
        //set stats
        this.badGuyType = "walker";
        this.damage = 2;
        this.speed = 1f;
        this.health = 3;
    }
}