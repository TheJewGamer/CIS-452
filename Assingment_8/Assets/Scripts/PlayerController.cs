/*
    * Jacob Cohen
    * PlayerController.cs
    * Assignment #7
    * controls player movement
*/

using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour 
{
     //variables
    private Vector2  movement;
    private Rigidbody2D rb2d;
    private Vector2 direction;
    public float speed = 4f;

    private bool up;
    private bool down;
    private bool left;
    private bool right;

    //foods
    private bool carringBlue;
    private bool carringGreen;
    private bool carringPink;

    private GameObject blueFood;
    private GameObject greenFood;
    private GameObject pinkFood;

    private void Start() 
    {
        //get componets
        rb2d = this.GetComponent<Rigidbody2D>();
        blueFood = this.gameObject.transform.GetChild(0).gameObject;
        greenFood = this.gameObject.transform.GetChild(1).gameObject;
        pinkFood = this.gameObject.transform.GetChild(2).gameObject;
        
        //setup
        up = false;
        down = false;
        left = false;
        right = true;
        carringBlue = false;
        carringGreen = false;
        carringPink = false;
    }

    // Update is called once per frame
    private void Update()
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

        //attack
        if(Input.GetKeyDown(KeyCode.Space) == true)
        {
            //raytrace
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, .5f);

            //check
            if(hit.collider != null)
            {
                if(hit.collider.CompareTag("greenFood") == true)
                {
                    greenFood.SetActive(true);
                    pinkFood.SetActive(false);
                    blueFood.SetActive(false);

                    carringGreen = true;
                    carringPink = false;
                    carringBlue = false;
                }
                else if(hit.collider.CompareTag("blueFood") == true)
                {
                    greenFood.SetActive(false);
                    pinkFood.SetActive(false);
                    blueFood.SetActive(true);

                    carringGreen = true;
                    carringPink = false;
                    carringBlue = true;
                }
                else if(hit.collider.CompareTag("pinkFood") == true)
                {
                    greenFood.SetActive(false);
                    pinkFood.SetActive(true);
                    blueFood.SetActive(false);

                    carringGreen = false;
                    carringPink = true;
                    carringBlue = false;
                }
                else if(hit.collider.CompareTag("wantsBlue") && carringBlue)
                {
                    //notify customer
                    hit.collider.gameObject.SendMessage("Served");

                    //update player
                    blueFood.SetActive(false);
                    carringBlue = false;
                }
                else if(hit.collider.CompareTag("wantsGreen") && carringGreen)
                {
                    //notify customer
                    hit.collider.gameObject.SendMessage("Served");

                    //update player
                    greenFood.SetActive(false);
                    carringGreen = false;
                }
                else if(hit.collider.CompareTag("wantsPink") && carringPink)
                {
                    //notify customer
                    hit.collider.gameObject.SendMessage("Served");

                    //update player
                    pinkFood.SetActive(false);
                    carringPink = false;
                }
            }
        }
    }
}