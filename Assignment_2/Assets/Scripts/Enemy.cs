/*
    * Jacob Cohen
    * Enemy.cs
    * Assignment #2
    * Controls the blobs that are enemies
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private Sprite hitSprite;
    private Sprite normalSprite;
    public float speed = .01f;
    public int health = 3;
    private int points = 25;

    // Start is called before the first frame update
    void Start()
    {
        //get player
        player = GameObject.FindWithTag("Player");
        hitSprite = GameObject.Find("enemyHitSprite").GetComponent<SpriteRenderer>().sprite;
        normalSprite = GameObject.Find("enemyNormalSprite").GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        //move towards player
        this.transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

        //look at player
        this.transform.right = (player.transform.position - transform.position) * -1;
    }

    //attacked
    void Shot()
    {
        //dec
        health--;

        //feedback
        StartCoroutine(Flash());

        //check to see if dead
        if(health <= 0)
        {
            Dead();
        }
    }

    //health is 0 or less
    void Dead()
    {
        //add to score
        player.GetComponentInChildren<Player>().Score(points);

        //remove game object
        Destroy(this.gameObject);
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
