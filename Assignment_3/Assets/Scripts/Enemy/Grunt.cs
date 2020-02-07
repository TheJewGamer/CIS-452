/*
    * Jacob Cohen
    * Grunt.cs
    * Assignment #3
    * Controls the Grunt also uses the strategy pattern
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Grunt : MonoBehaviour, IObserver
{
    //variables
    private bool seePlayer;
    public float speed;
    private LineRenderer lineOfSight;
    public Gradient redColor;
    public Gradient greenColor;
    private float distance;
    private Watcher watcher;
    private SpriteRenderer gruntSprite;
    private bool inProgress;
    public bool lookingLeft;
    public float eyeSightDistance = 5;
    private float waitTime;
    private float startWaitTime = 3;

    private void Start()
    {
        //set vars
        waitTime = startWaitTime;
        distance = eyeSightDistance;
        seePlayer = false;
        lineOfSight = GetComponentInChildren<LineRenderer>();
        gruntSprite = GetComponent<SpriteRenderer>();
        watcher = GameObject.FindGameObjectWithTag("Watcher").GetComponent<Watcher>();

        //pattern
        watcher.RegisterObserver(this);
    }

    private void Update()
    {
        //check
        if(!seePlayer)
        {
            if(waitTime <= 0)
            {
                //update var
                waitTime = startWaitTime;

                //move to next location
                if(lookingLeft)
                {
                    //look right
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                    lookingLeft = false;
                }
                else
                {
                    //look left
                    transform.localRotation = Quaternion.Euler(0, 180, 0);
                    lookingLeft = true;
                }
            }
            else
            {
                //wait
                waitTime -= Time.deltaTime;
            }
        }

        //var
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, distance);

        //check
        if(hit.collider != null)
        {
            lineOfSight.SetPosition(1, hit.point);
            //player seen
            if(hit.collider.CompareTag("Player"))
            {
                lineOfSight.colorGradient = redColor;
                //update vars
                seePlayer = true;
            }
            else
            {
                seePlayer = false;
                lineOfSight.colorGradient = greenColor;
            }   
        }
        else
        {
            lineOfSight.SetPosition(1, transform.position + transform.right * distance);
            seePlayer = false;
        }

        //line
        lineOfSight.SetPosition(0, transform.position);

        if(seePlayer)
        {
            //look at player
            this.transform.right = (hit.transform.position - transform.position);

            //go to player
            this.transform.position = Vector2.MoveTowards(this.transform.position, hit.transform.position, speed * Time.deltaTime);
        }
    }

    //player was able to sneak up on grunt
    public void Stabbed()
    {
        //remove from observer
        watcher.RemoveObserver(this);

        //remove gameObject
        Destroy(this.gameObject);
    }

    //watcher has seen player
    public void UpdateStatus(bool siteAlert, float sightDistance)
    {
        //check
        if(siteAlert)
        {
            distance = sightDistance;
        }
        else
        {
            distance = eyeSightDistance;
        }
    }
}