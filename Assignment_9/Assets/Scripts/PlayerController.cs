/*
    * Jacob Cohen
    * PlayerController.cs
    * Assignment #9
    * controls the player
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //variables
    private Vector2 movement;
    private Rigidbody2D rb2d;
    private Vector2 direction;
    public float speed = 1f;
    public FollowerController follower;

    private bool up;
    private bool down;
    private bool left;
    private bool right;

    // Start is called before the first frame update
    void Start()
    {
        //set vars
        up = false;
        down = false;
        left = false;
        right = true;

        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        //flip sprite based on direction
        if(movement.x < 0)
        {
            //feedback
            transform.localRotation = Quaternion.Euler(0, 180, 0);

            up = false;
            down = false;
            left = true;
            right = false;
        }
        else if(movement.x > 0)
        {
            //feedback
            transform.localRotation = Quaternion.Euler(0, 0, 0);

            up = false;
            down = false;
            left = false;
            right = true;
        }
        else if(movement.y > 0)
        {
            //feedback
            transform.localRotation = Quaternion.Euler(0, 0, 90);

            up = true;
            down = false;
            left = false;
            right = false;
        }
        else if(movement.y < 0)
        {
            //feedback;
            transform.localRotation = Quaternion.Euler(0, 0, -90);

            up = false;
            down = true;
            left = false;
            right = false;
        }
        else
        {
            if(left)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            else if(right)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else if(up)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 90);
            }
            else if(down)
            {
                transform.localRotation = Quaternion.Euler(0, 0, -90);
            }
        }

        //actually moving player here
        rb2d.MovePosition(rb2d.position + movement * speed * Time.fixedDeltaTime);

        //input follow
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //tell to follow
            follower.Follow(this.gameObject.transform);
        }

        //input stop following
        if(Input.GetKeyDown(KeyCode.V))
        {
            //tell to stop following
            follower.StopFollow();
        }

        //input pet
        if(Input.GetKeyDown(KeyCode.F))
        {
            //tell to calm down
            follower.Pet(this.gameObject.transform);
        }

        //feed pet
        if(Input.GetKeyDown(KeyCode.R))
        {
            //tell to be not tired
            follower.Feed(this.gameObject.transform);
        }
    }
}
