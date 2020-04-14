/*
    * Jacob Cohen
    * PlayerController.cs
    * Final Project
    * controls the player
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //variables
    private Vector2  movement;
    private Rigidbody2D rb2d;
    private float speed = 3f;
    private bool up;
    private bool down;
    private bool left;
    private bool right;

    // Start is called before the first frame update
    void Start()
    {
        //get componets
        rb2d = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //movement
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        //actually moving player here
        rb2d.MovePosition(rb2d.position + movement * speed * Time.fixedDeltaTime);

        //animation
        //flip sprite based on direction
        if(movement.x < 0)
        {
            //feedback
            transform.localRotation = Quaternion.Euler(0, 0, 90);

            up = false;
            down = false;
            left = true;
            right = false;
        }
        else if(movement.x > 0)
        {
            //feedback
            transform.localRotation = Quaternion.Euler(0, 0, -90);

            up = false;
            down = false;
            left = false;
            right = true;
        }
        else if(movement.y > 0)
        {
            //feedback
            transform.localRotation = Quaternion.Euler(0, 0, 0);

            up = true;
            down = false;
            left = false;
            right = false;
        }
        else if(movement.y < 0)
        {
            //feedback;
            transform.localRotation = Quaternion.Euler(0, 0, 180);

            up = false;
            down = true;
            left = false;
            right = false;
        }
        else
        {
            if(left)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 90);
            }
            else if(right)
            {
                transform.localRotation = Quaternion.Euler(0, 0, -90);
            }
            else if(up)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else if(down)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 180);
            }
        }
    }
}


