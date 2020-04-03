/*
    * Jacob Cohen
    * TutEnemy.cs
    * Assignment #9
    * controls the enemy in the tutorial level
*/

using UnityEngine;

public class TutEnemy : MonoBehaviour 
{
    //variable
    private GameObject follower;

    private void Start() 
    {
        this.gameObject.SetActive(false);    
        follower = GameObject.FindGameObjectWithTag("Follower");
    }    

    private void Update() 
    {
        //check to see if close to follower
        if(Vector2.Distance(follower.transform.position, transform.transform.position) < .5f)
        {
            //check to see if already scared
            if(follower.GetComponent<FollowerController>().scared == false)
            {
                //call
                follower.GetComponent<FollowerController>().NearEnemy();
            }
        }    
    }

    public void OnTriggerEnter2D(Collider2D other) 
    {
        //check to see if player
        if(other.gameObject.tag == "Player")
        {
            //dead
            Destroy(this.gameObject);
        }
    }    
    
}