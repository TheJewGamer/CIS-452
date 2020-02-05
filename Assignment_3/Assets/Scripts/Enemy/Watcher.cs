using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watcher : MonoBehaviour, ISubject
{
    //variables
    private List<IObserver> obs = new List<IObserver>();
    public Transform[] guardPoints;
    private int guardPointIndex = 0;
    public bool alerted;
    public float distance;
    public float rotaionSpeed;
    public Gradient redColor;
    public Gradient greenColor;
    private GameObject lastKnownPlayerPostion;
    private LineRenderer lineOfSight;
    private bool timeToMove;
    private bool moving;
    public int timeToWait;

    private void Start()
    {
        //raycast
        Physics2D.queriesStartInColliders = false;

        //set vars
        alerted = false;
        timeToMove = true;
        lineOfSight = GetComponentInChildren<LineRenderer>();
        lastKnownPlayerPostion = GameObject.Find("PlayerLastKnowLocation");
    }

    private void Update()
    {
        //get point to move to
        if(timeToMove)
        {
            //update var
            timeToMove = false;

            //get point to move to
            if(guardPointIndex == guardPoints.Length - 1)
            {
                guardPointIndex = 0;
            }
            //update var
            moving = true;
        }

        //moving to point
        if(moving  && !alerted)
        {
            //look at point
            this.transform.right = guardPoints[guardPointIndex].position - transform.position;

            //move to point
            this.transform.position = Vector2.MoveTowards(this.transform.position, guardPoints[guardPointIndex].position, speed * Time.deltaTime);
        }

        //check
        if(this.transform.position == guardPoints[guardPointIndex].position)
        {
            //update var
            moving = false;

            //start waiting
            StartCoroutine(Guarding());
        }

        //var
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, distance);

        //check
        if(hit.collider != null)
        {
            //feedback
            lineOfSight.SetPosition(1, hit.point);

            //player seen
            if(hit.collider.CompareTag("Player"))
            {
                //feedback
                lineOfSight.colorGradient = redColor;
                this.transform.right = player.transform.position - transform.position;

                //update vars
                alerted = true;
                lastKnownPlayerPostion.transform.position = hit.transform.position;

                //call
                NotifyObservers();
            }

            //done
            return;   
        }
        //nothing hit
        else
        {
            //feedback
            lineOfSight.SetPosition(1, transform.position + transform.right * distance);
        }

        //feeback
        lineOfSight.SetPosition(0, transform.position);
        lineOfSight.colorGradient = greenColor;

        //update var
        alerted = false;

        //call
        NotifyObservers();
    }


    public void RegisterObserver(IObserver ob)
    {
        //add to list
        obs.Add(ob);
    }

    public void RemoveObserver(IObserver ob)
    {
        //check
        if(obs.Contains(ob))
        {
            //remove
            obs.Remove(ob);
        }
    }

    //alert other units of player
    public void NotifyObservers()
    {
        //loop
        foreach(IObserver item in obs)
        {
            //set everything to alert
            item.UpdateStatus(alerted, lastKnownPlayerPostion);
        }
    }

    private IEnumerator Guarding()
    {
        //wait
        yield return new WaitForSeconds(timeToWait);

        //update var
        timeToMove = true;
    }
}