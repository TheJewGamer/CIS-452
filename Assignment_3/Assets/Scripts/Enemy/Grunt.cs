using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Grunt : MonoBehaviour, IObserver
{
    //variables
    public bool siteAlert;
    private bool seePlayer;
    public Transform lastKnownPlayerLocation;
    public float speed;
    private GameObject player;
    private LineRenderer lineOfSight;
    public Gradient redColor;
    public Gradient greenColor;
    public float distance;
    public float waitToSpawn;
    public float waitToTurn;
    public Watcher watcher;
    private SpriteRenderer gruntSprite;
    private bool inProgress;

    void Start()
    {
        //set vars
        siteAlert = false;
        seePlayer = false;
        inProgress = false;
        player = GameObject.FindWithTag("Player");
        lineOfSight = GetComponentInChildren<LineRenderer>();
        gruntSprite = GetComponent<SpriteRenderer>();

        watcher.RegisterObserver(this);
    }

    void Update()
    {
        //check
        if(!seePlayer && !inProgress)
        {
            Debug.Log("Start");
            inProgress = true;
            StartCoroutine(ChangeDirection());
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
            StopCoroutine(ChangeDirection());
            StartCoroutine(Wait());
        }
        else if(seePlayer)
        {
            //stop turning
            StopCoroutine(ChangeDirection());

            //look at player
            this.transform.right = (player.transform.position - transform.position);

            //go to player
            this.transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    //player was able to sneak up on grunt
    void Stabbed()
    {
        //remove from observer
        Watcher.RemoveObserver(this);

        //remove gameObject
        Destroy(this.gameObject);
    }

    IEnumerator Wait()
    {
        Debug.Log("start");

        yield return new WaitForSeconds(waitToSpawn);

        //move this object to site
        this.transform.position = lastKnownPlayerLocation.position;
    }

    IEnumerator ChangeDirection()
    {
        yield return new WaitForSeconds(waitToTurn);

        //random switch looking direction
        int rand = Random.Range(1,4);

        //check
        switch (rand)
        {
            //look right
            case 1:
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                gruntSprite.flipX = false;
                break;

            //look left
            case 2:
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                gruntSprite.flipX = true;
                break;

            //look up
            case 3:
                transform.localRotation = Quaternion.Euler(0, 0, 90);
                gruntSprite.flipX = false;
                break;
            
            //look down
                case 4:
                transform.localRotation = Quaternion.Euler(0, 0, -90);
                gruntSprite.flipX = false;
                break;

            //error
            default:
                Debug.Log("error");
                break;
        }

        //update var
        inProgress = false;
    }

    //watcher has seen player
    public void UpdateStatus(bool input, GameObject location)
    {
        siteAlert = input;
        lastKnownPlayerLocation = location.transform;
    }
}