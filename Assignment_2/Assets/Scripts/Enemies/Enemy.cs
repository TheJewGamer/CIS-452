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

public abstract class Enemy : MonoBehaviour
{
    //variables
    public MovementBehavior MovementBehavior {get; set;}
    private GameObject player;
    private Sprite hitSprite;
    private Sprite normalSprite;
    public int health = 3;
    private int points = 25;
    private bool runner = false;

    //change movement speed
    public virtual void DoMove()
    {
        MovementBehavior.Move(player);
    }

    // Start is called before the first frame update
    public void Start()
    {
        //get objects
        player = GameObject.FindWithTag("Player");
        hitSprite = GameObject.Find("enemyHitSprite").GetComponent<SpriteRenderer>().sprite;
        normalSprite = GameObject.Find("enemyNormalSprite").GetComponent<SpriteRenderer>().sprite;

    }

    // Update is called once per frame
    public void Update()
    {
        DoMove();
    }

    //attacked
    public void Shot()
    {
        //dec
        health--;

        //feedback
        StartCoroutine(Flash());

        //check to see if dead
        if(health <= 0)
        {
            //call
            Dead();

            //done
            return;
        }

        //chance to become enraged
        int chance = Random.Range(1,100);
        
        //check
        if(chance > 80 && !runner)
        {
            //remove walk
            Destroy(GetComponent<MovementBehavior>());

            //set movement to run
            MovementBehavior = gameObject.AddComponent<MovementRun>();
        }
    }

    //health is 0 or less
    private void Dead()
    {
        //check to see if runner
        if(runner)
        {
            points = 50;
        }

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
