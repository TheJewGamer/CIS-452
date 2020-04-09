/*
    * Jacob Cohen
    * RunnerEnemy.cs
    * Assignment #10
    * Controllers the runner enemy
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerEnemy : MonoBehaviour
{
    //variables
    private int health = 1;
    private float speed = 3f;
    public Sprite hitSprite;
    public Sprite normalSprite;
    private GameObject player;
    private ObjectPool pooler;

    public void Start()
    {
        //get objects
        player = GameObject.FindWithTag("Player");
        pooler = GameObject.Find("Scripts").GetComponent<ObjectPool>();
    }

    private void OnEnable() 
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = normalSprite;
    }

    public void Update()
    {
        //move towards player
        this.transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

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
            pooler.Dead("Runner", this.gameObject);
        }
    }

    public void AttackedPlayer()
    {
        pooler.Dead("Runner", this.gameObject);
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