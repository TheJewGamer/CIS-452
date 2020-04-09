/*
    * Jacob Cohen
    * PlayerController.cs
    * Assignment #10
    * controls the player
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //variables
    private Vector2  movement;
    private Rigidbody2D rb2d;
    public GameObject gameOverMenu;
    public GameObject winMenu;
    private int health = 5;
    private Vector2 direction;
    private float speed = 3f;
    public GameObject muzzelFlash;
    public GameObject hitEffect;
    private int pickupCount;

    // Start is called before the first frame update
    void Start()
    {
        //get componets
        rb2d = this.GetComponent<Rigidbody2D>();
        muzzelFlash.SetActive(false);

        //set up
        pickupCount = 0;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //movement
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        //actually moving player here
        rb2d.MovePosition(rb2d.position + movement * speed * Time.fixedDeltaTime);

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
                if(hit.collider.CompareTag("Enemy") || hit.collider.CompareTag("TUTEnemy"))
                {
                    //notify
                    hit.transform.SendMessageUpwards("Attacked");
                }
            }
        }
    }

    //enemy overlapped player
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Enemy")
        {
            //disable enemy that hit player
            if(other.gameObject.GetComponent<RunnerEnemy>() != null)
            {
                other.gameObject.GetComponent<RunnerEnemy>().AttackedPlayer();
            }
            else
            {
                other.gameObject.GetComponent<WalkerEnemy>().AttackedPlayer();
            }

            //dec
            health--;

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

    public void PickUp()
    {
        //inc
        pickupCount++;

        //check
        if(pickupCount == 10)
        {
            //done
            Time.timeScale = 0;

            winMenu.SetActive(true);
        }
        else
        {
            //done
            return;
        }
    }
}


