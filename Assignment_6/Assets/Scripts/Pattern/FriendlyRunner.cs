/*
    * Jacob Cohen
    * FriendlyRunner.cs
    * Assignment #6
    * sets the stats for a friendly runner
*/

using UnityEngine;

public class FriendlyRunner : Character
{
    //constructor
    public FriendlyRunner()
    {
        //set stats
        this.health = 2;
        this.speed = 6f;
        this.damage = 1;
        this.friendly = true;
    }

    private void LateUpdate()
    {
        //get nearest enemy
        nearestEnemy = NearestEnemy();

        if(nearestEnemy != null)
        {
            //move towards enemy
            this.transform.position = Vector2.MoveTowards(this.transform.position, nearestEnemy.transform.position, speed * Time.deltaTime);
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
}