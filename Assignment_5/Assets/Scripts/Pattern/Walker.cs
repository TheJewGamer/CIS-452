using UnityEngine;

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
        this.speed = 2.5f;
        this.health = 3;
    }

    private void Awake() 
    {
        //set sprite
        GetComponent<SpriteRenderer>().sprite = GameObject.Find("walkerSprite").GetComponent<SpriteRenderer>().sprite;


    }
}