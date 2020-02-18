/*
    * Jacob Cohen
    * PlayerController.cs
    * Assignment #5
    * controls the player
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    //variables
    private Vector2  movement;
    private Rigidbody2D rb2d;
    public GameObject gameOverMenu;
    public GameObject winMenu;
    public float speed = 2f;
    private int health;
    private Vector2 direction;
    public GameObject hitEffect;
    public GameObject muzzelFlash;
    
    // Start is called before the first frame update
    void Start()
    {
        //get componets
        rb2d = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
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
}
