using UnityEngine;

public class FollowerController : MonoBehaviour 
{
    //variables
    public Transform target = null;
    public bool scared = false;
    public GameObject playerHolder;
    public GameObject[] enemies;
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
}