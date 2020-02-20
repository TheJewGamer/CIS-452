using UnityEngine;

/*
    * Jacob Cohen
    * Runner.cs
    * Assignment #5
    * sets the runner's stats
*/
public class Runner :BadGuy
{
    //constructor
    public Runner()
    {
        //set stats
        this.badGuyType = "Runner";
        this.damage = 1;
        this.speed = 3.5f;
        this.health = 1;
    }

    private void Awake() 
    {
        //set sprite
         GetComponent<SpriteRenderer>().sprite = GameObject.Find("runnerSprite").GetComponent<SpriteRenderer>().sprite;

    }
}