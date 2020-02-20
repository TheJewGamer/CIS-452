/*
    * Jacob Cohen
    * Heavy.cs
    * Assignment #5
    * sets the heavy's stats
*/

using UnityEngine;

public class Heavy : BadGuy 
{
    //constructor
    public Heavy()
    {
        //set stats
        this.badGuyType = "heavy";
        this.damage = 3;
        this.speed = 1.5f;
        this.health = 5;
    }

    private void Awake() 
    {
        //set sprite
        GetComponent<SpriteRenderer>().sprite = GameObject.Find("heavySprite").GetComponent<SpriteRenderer>().sprite;


    }
}