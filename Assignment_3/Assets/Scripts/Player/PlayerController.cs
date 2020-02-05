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
    private bool hidden;
    private bool moving;
    private Rigidbody2D rb2d;
    private float speed = 3f;
    private Collider2D knife;

    // Start is called before the first frame update
    void Start()
    {
        //get componets
        playerSprite = this.GetComponent<SpriteRenderer>();
        rb2d = this.GetComponent<Rigidbody2D>();
        knife = this.GetComponentInChildren<Collider2D>();

        //set vars
        hidden = false;
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
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            playerSprite.sprite = playerVisiableSprite;
            playerSprite.flipX = true;
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
            playerSprite.flipX = false;
        }
        else if(movement.y > 0)
        {
            //update vars
            moving = true;
            gameObject.tag = "Player";
            gameObject.layer = 0;

            //feedback
            transform.localRotation = Quaternion.Euler(0, 0, 90);
            playerSprite.flipX = false;
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
            playerSprite.flipX = false;
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
            hidden = true;
            gameObject.tag = "Hidden";
            gameObject.layer = 2;

            //feedback
            playerSprite.sprite = playerHiddenSprite;
        }

        //stab
        if(Input.GetKeyDown(KeyCode.F) == true)
        {
            //check to see if knife collider is overlapping a grunt

        }
    }

    void LateUpdate()
    {
        //actually moving player here
        rb2d.MovePosition(rb2d.position + movement * speed * Time.fixedDeltaTime);
    }

    public void Caught()
    {
        Debug.Log("Game Over");
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
