using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected int health;
    protected float speed;
    protected int damage;
    protected bool friendly;
    public GameObject player;
    private GameObject nearestEnemy;

    private void Start() 
    {
        //set tag
        if(friendly)
        {
            this.gameObject.tag = "Friendly";
        }    
        else
        {
            this.gameObject.tag = "Enemy";
        }
    }

    private void LateUpdate()
    {
        //check to see if friendly
        if(friendly)
        {
            //get nearest enemy
            nearestEnemy = NearestEnemy();

            //move towards enemy
            this.transform.position = Vector2.MoveTowards(this.transform.position, nearestEnemy.transform.position, speed * Time.deltaTime);

            //look at enemy
            this.transform.right = (nearestEnemy.transform.position - transform.position);

        }
        else
        {
            //move towards player
            this.transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

            //look at player
            this.transform.right = (player.transform.position - transform.position);
        }
    }

    public void Attacked(int damage)
    {
        //dec
        health--;

        //check
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private GameObject NearestEnemy()
    {
        //vars
        GameObject[] objs;
        GameObject nearest = null;

        //setup
        objs = GameObject.FindGameObjectsWithTag("Enemy");
        float distance = Mathf.Infinity;
        Vector3 position = this.transform.position;

        //loop
        foreach(GameObject item in objs)
        {
            Vector3 difference = item.transform.position - position;
            float currentDistance = difference.sqrMagnitude;
            
            //check
            if(currentDistance < distance)
            {
                nearest = item;
                distance = currentDistance;
            }
        }

        //done
        return nearest;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        //check
        if(other.gameObject.tag == "Friendly")
        {
            //attacked
            other.gameObject.GetComponent<Character>().Attacked(damage);

            //destory this gameObject
            Destroy(this.gameObject);
        }     
    }
}