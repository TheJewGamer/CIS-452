using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //variables
    private int health = 10;
    private Sprite hitSprite;
    private Sprite normalSprite;
    private GameObject player;
    private int damage;

    public void Start()
    {
        //get objects
        player = GameObject.FindWithTag("Player");
        hitSprite = GameObject.Find("enemyHitSprite").GetComponent<SpriteRenderer>().sprite;
        normalSprite = GameObject.Find("enemyNormalSprite").GetComponent<SpriteRenderer>().sprite;
        damage = player.GetComponent<PlayerController>().GetDamage();
    }

    public void Update()
    {
        //move towards player
        this.transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, 3f * Time.deltaTime);

        //look at player
        this.transform.right = (player.transform.position - transform.position);
    }

    public void Attacked()
    {
        //dec
        health -= damage;

        //feedback
        StartCoroutine(Flash());

        //check
        if(health <= 0)
        {
            //dead
            Destroy(gameObject);
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