/*
    * Jacob Cohen
    * PlayerController.cs
    * Assignment #4
    * controls the player
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //variables
    public Character character;
    private Vector2  movement;
    private Rigidbody2D rb2d;
    public GameObject gameOverMenu;
    public GameObject winMenu;
    private int health;
    private Vector2 direction;
    public GameObject hitEffect;
    public GameObject muzzelFlash;
    public Image healthDisplay;
    private float healthDisplayInc;

    // Start is called before the first frame update
    void Start()
    {
        //get componets
        rb2d = this.GetComponent<Rigidbody2D>();
    }

    public void SetCharacter(Character input)
    {
        //set vars
        this.character = input;
        health = this.character.GetHealth();
        healthDisplayInc = (255f/(float)health) / 250f;
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        //actually moving player here
        rb2d.MovePosition(rb2d.position + movement * character.GetSpeed() * Time.fixedDeltaTime);

         //look towards mouse
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.right= direction;

        //Attack
        if(Input.GetMouseButtonDown(0) == true)
        {
            //feedback
            StartCoroutine(Flash());

            //raytrace
            RaycastHit2D hit = Physics2D.Raycast(transform.position, this.direction);

            if(hit.collider !=null)
            {
                //enemy hit
                if(hit.collider.CompareTag("Enemy"))
                {
                    //notify
                    hit.transform.SendMessageUpwards("Attacked");
                }
            }
        }
    }

    //enemy overlapped player
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            //destory enemy that hit player
            Destroy(other.gameObject);

            //dec
            health--;

            //update health display
            Color temp = healthDisplay.color;
            temp.a += healthDisplayInc;
            healthDisplay.color = temp;

            //flash hit
            StartCoroutine(hitFlash());

            //check
            if(health == 0)
            {
                //stop game
                Time.timeScale = 0;

                //open menu
                gameOverMenu.SetActive(true);
            }
        }
    }

    //red flash effect
    private IEnumerator hitFlash()
    {
        //enable
        hitEffect.SetActive(true);

        yield return new WaitForSeconds(.05f);

        hitEffect.SetActive(false);
    }

    //send damage to enemy
    public int GetDamage()
    {
        return character.GetDamage();
    }

    //muzzle flash
    private IEnumerator Flash()
    {
        //enable
        muzzelFlash.SetActive(true);

        //wait
        yield return new WaitForSeconds(.05f);

        //turn off
        muzzelFlash.SetActive(false);
    }
}


