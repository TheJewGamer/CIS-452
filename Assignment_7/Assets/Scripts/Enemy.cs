/*
    * Jacob Cohen
    * Enemy.cs
    * Assignment #7
    * Controls the enemies
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //variables
    private bool seePlayer;
    public float speed;
    private LineRenderer lineOfSight;
    public Gradient redColor;
    public Gradient greenColor;
    private float distance;
    public float eyeSightDistance = 5;
    private float waitTime;
    private float startWaitTime = 3;
    public GameObject point1;
    public GameObject point2;
    private GameObject currentPoint;
    private bool moving;

    private void Start()
    {
        //set vars
        waitTime = startWaitTime;
        distance = eyeSightDistance;
        seePlayer = false;
        lineOfSight = GetComponentInChildren<LineRenderer>();
        currentPoint = point1;
    }

    private void Update()
    {
        //move to guard point
        this.transform.position = Vector2.MoveTowards(this.transform.position, currentPoint.transform.position, speed * Time.deltaTime);

        //check to see if at guard point
        if(Vector2.Distance(this.transform.position, currentPoint.transform.position) < .2f)
        {
            //check to see if done waiting
            if(waitTime <= 0)
            {
                //update var
                waitTime = startWaitTime;

                //move to next location
                if(currentPoint == point1)
                {
                    currentPoint = point2;
                }
                else
                {
                    currentPoint = point1;
                }
            }
            else
            {
                //wait
                waitTime -= Time.deltaTime;
            }
        }
        else
        {
            //look at point
            this.transform.right = currentPoint.transform.position - transform.position;
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
            lineOfSight.colorGradient = greenColor;
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

    public void Attacked(GameObject player)
    {
        //kill
        Destroy(this.gameObject);
    }
}