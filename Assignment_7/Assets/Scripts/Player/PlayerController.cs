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
    public GameObject gameOverMenu;
    public GameObject winMenu;
    private Vector2  movement;
    private Rigidbody2D rb2d;
    private Vector2 direction;
    public float speed = 4f;

    private bool up;
    private bool down;
    private bool left;
    private bool right;

    private void Start() 
    {
        //get componets
        rb2d = this.GetComponent<Rigidbody2D>();
        Time.timeScale = 1;

        //setup
        up = false;
        down = false;
        left = false;
        right = true;
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
        if(Input.GetKeyDown(KeyCode.V) == true)
        {
            //raytrace
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 1.5f);

            //check
            if(hit.collider != null)
            {
                if(hit.collider.CompareTag("Enemy") == true)
                {
                    //kill
                    DestroyImmediate(hit.collider.gameObject);

                    //call
                    WinCheck();
                }
                else if(hit.collider.CompareTag("TutEnemy") == true)
                {
                    //kill
                    hit.collider.gameObject.SendMessage("Attacked");
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        //check
        if(other.gameObject.CompareTag("Enemy") == true)
        {
            //stop game
            Time.timeScale = 0;

            //open menu
            gameOverMenu.SetActive(true);
        }    
    }

    public void WinCheck()
    {
        //var
        GameObject test = null; 

        try
        {
            //get enemy if there is any
            test = GameObject.FindGameObjectWithTag("Enemy");
        }
        catch
        {
            // This is bad, but hey it works
        }
        
        //check to see if there are any enemies on the map
        if(test == null)
        {
            //player wins
            Time.timeScale = 0;
            winMenu.SetActive(true);

            //done
            return;
        } 
    }
}