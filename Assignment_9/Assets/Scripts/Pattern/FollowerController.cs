/*
    * Jacob Cohen
    * FollowerController.cs
    * Assignment #9
    * Controlls the follower
*/

using UnityEngine;

public class FollowerController : MonoBehaviour 
{
    //variables
    public Transform target = null;
    public bool scared = false;
    public GameObject playerHolder;
    public GameObject[] enemies;
    public Sprite scaredSprite;
    public Sprite normalSprite;
    public Sprite tiredSprite;
    public GameObject loseMenu;
    private float speed = .5f;

    //pattern
    public FollowerStates idleState {get; set;}
    public FollowerStates scaredState {get; set;}
    public FollowerStates tiredState {get; set;}
    public FollowerStates currentState {get; set;}
    public FollowerStates followState {get; set;}

    //start
    private void Start() 
    {
        //set up
        idleState = gameObject.AddComponent<IdleState>();
        scaredState = gameObject.AddComponent<ScaredState>();
        tiredState = gameObject.AddComponent<TiredState>();
        followState = gameObject.AddComponent<FollowState>();
        currentState = idleState;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        loseMenu.SetActive(false);
    }

    private void LateUpdate() 
    {
        if(target != null && Vector2.Distance(this.gameObject.transform.position, target.transform.position) > .25f)
        {
            //move towards target
            this.gameObject.transform.position = Vector2.MoveTowards(this.gameObject.transform.position, target.transform.position, speed * Time.deltaTime);

            //look at target
            if(target != this.gameObject.transform)
            {
                this.gameObject.transform.right = target.transform.position - transform.position;
            }
        }    
    }

    public void Follow(Transform playerLocation)
    {
        Debug.Log("Start follow");
        //check to see if in range
        if(Vector2.Distance(playerLocation.position, transform.transform.position) < 1f)
        {
            Debug.Log("Told to follow");
            //call
            currentState.StartFollowing();
        }
    }

    public void StopFollow()
    {
        //tell to calm down
        currentState.StopFollowing();
    }

    public void Pet(Transform playerLocation)
    {
        //check to see if in range
        if(Vector2.Distance(playerLocation.position, transform.transform.position) < .5f)
        {
            //tell to calm down
            currentState.CalmDown();
        }
    }

    public void Feed(Transform playerLocation)
    {
        //check to see if in range
        if(Vector2.Distance(playerLocation.position, transform.transform.position) < .5f)
        {
            //tell to not be tired
            currentState.Fed();
        }
    }

    public void NearEnemy()
    {
        //tell to be scared
        currentState.Scared();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //check to see if enemy
        if(other.gameObject.tag == "Enemy")
        {
            //game over
            loseMenu.SetActive(true);

            //pause
            Time.timeScale = 0;
        }    
    }
}