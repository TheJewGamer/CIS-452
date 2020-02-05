using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Grunt : MonoBehaviour, IObserver
{
    //variables
    public bool siteAlert;
    private bool seePlayer;
    private Transform lastKnownPlayerLocation;
    public float speed;
    private GameObject player;
    private LineRenderer lineOfSight;
    public Gradient redColor;
    public Gradient greenColor;
    public float distance;
    public float waitToSpawn;

    public Watcher watcher;

    void Start()
    {
        //set vars
        siteAlert = false;
        seePlayer = false;
        player = GameObject.FindWithTag("Player");
        lineOfSight = GetComponentInChildren<LineRenderer>();

        watcher.RegisterObserver(this);
    }

    void Update()
    {
        //random switch looking direction
        int rand = Random.Range(1,100);

        //check
        if(rand > 15 && rand < 25)
        {
            //look right
        }
        else if(rand > 25 && rand < 35)
        {
            //look left
        }
        else if(rand > 35 && rand < 45)
        {
            //look up
        }
        else if (rand > 45 && rand < 55)
        {
            //look down
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
            }   
        }
        else
        {
            lineOfSight.SetPosition(1, transform.position + transform.right * distance);
            seePlayer = false;
        }

        //line
        lineOfSight.SetPosition(0, transform.position);
        lineOfSight.colorGradient = greenColor;

        //check
        if(siteAlert && !seePlayer)
        {
            //wait
            StartCoroutine(Wait());
        }
        else if(seePlayer)
        {
            //look at player
            this.transform.right = (player.transform.position - transform.position);

            //go to player
            this.transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    IEnumerator Wait()
    {
        Debug.Log("start");

        yield return new WaitForSeconds(waitToSpawn);

        //move this object to site
        this.transform.position = lastKnownPlayerLocation.position;
    }

    public void UpdateStatus(bool input, Transform location)
    {
        siteAlert = input;
        lastKnownPlayerLocation = location;
    }
}