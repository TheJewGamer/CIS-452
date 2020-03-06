/*
    * Jacob Cohen
    * TutEnemy.cs
    * Assignment #7
    * Controls the tutorial enemy
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TutEnemy : MonoBehaviour
{
    //variables
    private bool seePlayer;
    public float speed;
    private LineRenderer lineOfSight;
    public Gradient redColor;
    public Gradient greenColor;
    private float distance;
    public float eyeSightDistance = 5;
    public TutManager manager;

    private void Start()
    {
        //set vars
        distance = eyeSightDistance;
        seePlayer = false;
        lineOfSight = GetComponentInChildren<LineRenderer>();
    }

    private void Update()
    {
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
        }
    }

    public void Attacked()
    {
        manager.SendMessage("EnemyKilled");
        Destroy(this.gameObject);
    }
}