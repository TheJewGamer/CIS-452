using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    public float speed = .01f;
    public int health = 3;

    private int points = 25;

    // Start is called before the first frame update
    void Start()
    {
        //get player
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //move towards player
        this.transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }

    //attacked
    void Shot()
    {
        Debug.Log("health");

        health--;

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
}
