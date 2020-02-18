/*
    * Jacob Cohen
    * Runner.cs
    * Assignment #5
    * sets the runner's stats
*/
public class Runner : BadGuy 
{
    //constructor
    public Runner()
    {
        //set stats
        this.badGuyType = "Runner";
        this.damage = 1;
        this.speed = 3f;
        this.health = 2;
    }
}