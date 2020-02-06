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
    private LineRenderer lineOfSight;
    public float speed;
    private float waitTime;
    public float startWaitTime = 7;
    public float alertedGruntSightDistance = 8;


    private void Start()
    {
        //raycast
        Physics2D.queriesStartInColliders = false;

        //set vars
        alerted = false;
        waitTime = startWaitTime;
        lineOfSight = GetComponentInChildren<LineRenderer>();
    }

    private void Update()
    {
        //move to guard point
        this.transform.position = Vector2.MoveTowards(this.transform.position, guardPoints[guardPointIndex].position, speed * Time.deltaTime);

        //check to see if at guard point
        if(Vector2.Distance(this.transform.position, guardPoints[guardPointIndex].position) < .2f)
        {
            //check to see if done waiting
            if(waitTime <= 0)
            {
                //update var
                waitTime = startWaitTime;

                //move to next location
                if(guardPointIndex == guardPoints.Length - 1)
                {
                    guardPointIndex = 0;
                }
                else
                {
                    
                    guardPointIndex++;
                }
            }
            else
            {
                //wait
                waitTime -= Time.deltaTime;

                //rotate
                transform.Rotate(Vector3.forward * rotaionSpeed * Time.deltaTime);
            }
        }
        else
        {
            //look at guard point
            this.transform.right = guardPoints[guardPointIndex].transform.position - transform.position;
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
                //stop
                StopCoroutine(AlertReset());

                //feedback
                lineOfSight.colorGradient = redColor;
                this.transform.right = hit.transform.position - transform.position;

                //update vars
                alerted = true;

                //call
                NotifyObservers();

                //start time
                StartCoroutine(AlertReset());

            } 
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

    IEnumerator AlertReset()
    {
        yield return new WaitForSeconds(10);

        alerted = false;

        NotifyObservers();
    }

    //alert other units of player
    public void NotifyObservers()
    {
        //loop
        foreach(IObserver item in obs)
        {
            //set everything to alert
            item.UpdateStatus(alerted, alertedGruntSightDistance);
        }
    }
}