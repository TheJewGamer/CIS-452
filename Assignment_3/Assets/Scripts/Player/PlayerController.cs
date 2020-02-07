/*
    * Jacob Cohen
    * PlayerController.cs
    * Assignment #3
    * Controls the player
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //variables
    private Vector2 movement;
    private SpriteRenderer playerSprite;
    public Sprite playerHiddenSprite;
    public Sprite playerVisiableSprite;
    private bool moving;
    private Rigidbody2D rb2d;
    private float speed = 3f;
    private Collider2D knife;
    public GameObject GameOverMenu;

    // Start is called before the first frame update
    void Start()
    {
        //get componets
        playerSprite = this.GetComponent<SpriteRenderer>();
        rb2d = this.GetComponent<Rigidbody2D>();
        knife = this.GetComponentInChildren<Collider2D>();

        //set vars
        moving = false;
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
            //update vars
            moving = true;
            gameObject.tag = "Player";
            gameObject.layer = 0;

            //feedback
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            playerSprite.sprite = playerVisiableSprite;
        }
        else if(movement.x > 0)
        {
            //update vars
            moving = true;
            gameObject.tag = "Player";
            gameObject.layer = 0;

            //feedback
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            playerSprite.sprite = playerVisiableSprite;
        }
        else if(movement.y > 0)
        {
            //update vars
            moving = true;
            gameObject.tag = "Player";
            gameObject.layer = 0;

            //feedback
            transform.localRotation = Quaternion.Euler(0, 0, 90);
            playerSprite.sprite = playerVisiableSprite;
        }
        else if(movement.y < 0)
        {
            //update vars
            moving = true;
            gameObject.tag = "Player";
            gameObject.layer = 0;

            //feedback
            transform.localRotation = Quaternion.Euler(0, 0, -90);
            playerSprite.sprite = playerVisiableSprite;
        }
        else
        {
            moving = false;
        }

        ///INPUT

        //hide
        if(Input.GetKeyDown(KeyCode.Space) == true && !moving)
        {
            //update vars
            gameObject.tag = "Hidden";
            gameObject.layer = 2;

            //feedback
            playerSprite.sprite = playerHiddenSprite;
        }

        //stab
        if(Input.GetKeyDown(KeyCode.F) == true)
        {
            //raytrace
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 1.5f);

            //check
            if(hit.collider != null)
            {
                if(hit.collider.CompareTag("Grunt") == true)
                {
                    //call
                    hit.collider.SendMessage("Stabbed");
                }
            }
        }
    }

    void LateUpdate()
    {
        //actually moving player here
        rb2d.MovePosition(rb2d.position + movement * speed * Time.fixedDeltaTime);
    }

    public void Caught()
    {
        //pause
        Time.timeScale = 0;

        //open menu
        GameOverMenu.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //check
        if(other.CompareTag("Grunt") || other.CompareTag("Watcher"))
        {
            //call
            Caught();
        }
    }
}
