using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watcher : MonoBehaviour, ISubject
{
    //variables
    private List<IObserver> obs = new List<IObserver>();
    public bool alerted;
    public float distance;
    public float rotaionSpeed;
    public Gradient redColor;
    public Gradient greenColor;
    private Transform lastKnownPlayerPostion;
    private Transform playerPostion;
    private LineRenderer lineOfSight;

    void Start()
    {
        //raycast
        Physics2D.queriesStartInColliders = false;

        //set vars
        alerted = false;
        playerPostion = GameObject.FindGameObjectWithTag("Player").transform;
        lineOfSight = GetComponentInChildren<LineRenderer>();
    }

    void Update()
    {
        //rotate this
        transform.Rotate(Vector3.forward * rotaionSpeed * Time.deltaTime);

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
                alerted = true;
                lastKnownPlayerPostion = playerPostion;
                NotifyObservers();
            }

            //done
            return;   
        }
        else
        {
            lineOfSight.SetPosition(1, transform.position + transform.right * distance);
        }

        lineOfSight.SetPosition(0, transform.position);
        lineOfSight.colorGradient = greenColor;

        alerted = false;
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
}