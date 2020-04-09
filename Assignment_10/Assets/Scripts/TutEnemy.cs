/*
    * Jacob Cohen
    * TutEnemy.cs
    * Assignment #10
    * Controllers the enemy in the tutorial
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutEnemy : MonoBehaviour
{
    //variables
    private int health = 3;
    public Sprite hitSprite;
    public Sprite normalSprite;
    private GameObject player;

    public void Start()
    {
        //get objects
        player = GameObject.FindWithTag("Player");
    }

    private void OnEnable() 
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = normalSprite;
    }

    public void LateUpdate()
    {
        //look at player
        this.transform.right = (player.transform.position - transform.position);
    }

    public void Attacked()
    {
        //dec
        health--;

        //feedback
        StartCoroutine(Flash());

        //check
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    //flash hit sprite
    private IEnumerator Flash()
    {
        //change
        this.gameObject.GetComponent<SpriteRenderer>().sprite = hitSprite;

        //wait 
        yield return new WaitForSeconds(.05f);

        //revert
        this.gameObject.GetComponent<SpriteRenderer>().sprite = normalSprite;
    }
}