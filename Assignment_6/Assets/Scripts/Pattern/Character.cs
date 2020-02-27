/*
    * Jacob Cohen
    * Character.cs
    * Assignment #6
    * sets up the character object for the design pattern
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected int health;
    protected float speed;
    public int damage;
    public bool friendly = false;
    protected GameObject player;
    protected GameObject nearestEnemy;
    private Sprite normalSprite;
    private Sprite hitSprite;

    private void Start() 
    {
        //set tag and layer
        if(friendly)
        {
            this.gameObject.tag = "Friendly";
            this.gameObject.layer = 2;
        }    
        else
        {
            this.gameObject.tag = "Enemy";
            this.gameObject.layer = 0;
        }

        //get componets
        normalSprite = this.GetComponent<SpriteRenderer>().sprite;
        hitSprite = GameObject.Find("hitSprite").GetComponent<SpriteRenderer>().sprite;
        player = GameObject.FindWithTag("Player");

    }

    public void Attacked(int damage)
    {
        //dec
        health--;

        //flash
        StartCoroutine(hitFeedback());

        //check
        if(health <= 0)
        {
            //add special ammo
            player.GetComponent<PlayerController>().EnemyKilled();

            //kill
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D other) 
    {
        //check
        if(other.gameObject.tag == "Friendly" && this.gameObject.tag == "Enemy")
        {
            //attacked
            this.gameObject.GetComponent<Character>().Attacked(damage);

            //destory this gameObject
            Destroy(other.gameObject);
        } 
    }

    private IEnumerator hitFeedback()
    {
        //change
        this.gameObject.GetComponent<SpriteRenderer>().sprite = hitSprite;

        //wait 
        yield return new WaitForSeconds(.05f);

        //revert
        this.gameObject.GetComponent<SpriteRenderer>().sprite = normalSprite;
    }
    
}