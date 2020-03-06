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

    private void Start() 
    {
        //get componets
        rb2d = this.GetComponent<Rigidbody2D>();
        Time.timeScale = 1;
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
            //update vars
            gameObject.tag = "Player";
            gameObject.layer = 0;

            //feedback
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if(movement.x > 0)
        {
            //update vars
            gameObject.tag = "Player";
            gameObject.layer = 0;

            //feedback
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if(movement.y > 0)
        {
            //update vars
            gameObject.tag = "Player";
            gameObject.layer = 0;

            //feedback
            transform.localRotation = Quaternion.Euler(0, 0, 90);
        }
        else if(movement.y < 0)
        {
            //update vars
            gameObject.tag = "Player";
            gameObject.layer = 0;

            //feedback
            transform.localRotation = Quaternion.Euler(0, 0, -90);
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