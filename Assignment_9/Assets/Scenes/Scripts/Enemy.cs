using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //variable
    private GameObject follower;

    // Start is called before the first frame update
    void Start()
    {
        follower = GameObject.FindWithTag("Follower");
    }

    // Update is called once per frame
    void Update()
    {
        //check to see if close to follower
        if(Vector2.Distance(follower.transform.position, transform.transform.position) < 1f)
        {
            //check to see if already scared
            if(follower.GetComponent<FollowerController>().scared == false)
            {
                //call
                follower.GetComponent<FollowerController>().NearEnemy();
            }

            //slowly move towards follower
        }        
    }
}
