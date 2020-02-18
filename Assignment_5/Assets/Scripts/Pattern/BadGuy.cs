/*
    * Jacob Cohen
    * BadGuy.cs
    * Assignment #5
    * controls the badGuys
*/

using System.Collections;
using UnityEngine;

public class BadGuy : MonoBehaviour
{
    //stats
    protected string badGuyType{get; set;}
    protected int damage{get; set;}
    protected float speed{get; set;}
    protected int health{get; set;}

    //vars
    private GameObject player;
    private Sprite hitSprite;
    private Sprite normalSprite;

    private void Start() 
    {
        //set vars
        player = GameObject.FindWithTag("Player");
        hitSprite = GameObject.Find("enemyHitSprite").GetComponent<SpriteRenderer>().sprite;
        normalSprite = GameObject.Find("enemyNormalSprite").GetComponent<SpriteRenderer>().sprite;
    }

    public void Attacked()
    {
        //dec
        health--;

        //flash
        StartCoroutine(hitFeedback());

        //check
        if(health == 0)
        {
            //dead
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
         //move towards player
        this.transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, 3f * Time.deltaTime);

        //look at player
        this.transform.right = (player.transform.position - transform.position);
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
