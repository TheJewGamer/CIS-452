/*
    * Jacob Cohen
    * TutorialEnemy.cs
    * Assignment #2
    * Controls the blobs in the tutorial
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialEnemy : MonoBehaviour
{
    //variables
    public MovementBehavior MovementBehavior {get; set;}
    private GameObject player;
    private Sprite hitSprite;
    private Sprite normalSprite;
    public int health = 3;
    private int points = 25;

    // Start is called before the first frame update
    public void Start()
    {
        //get player
        player = GameObject.FindWithTag("Player");
        hitSprite = GameObject.Find("enemyHitSprite").GetComponent<SpriteRenderer>().sprite;
        normalSprite = GameObject.Find("enemyNormalSprite").GetComponent<SpriteRenderer>().sprite;

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
            Dead();
        }
    }

    //health is 0 or less
    private void Dead()
    {
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
