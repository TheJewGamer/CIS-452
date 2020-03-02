/*
    * Jacob Cohen
    * PlayerController.cs
    * Assignment #6
    * controls the player
*/

using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    //variables
    private Vector2  movement;
    private Rigidbody2D rb2d;
    public GameObject gameOverMenu;
    public GameObject winMenu;
    public float speed = 4f;
    private Vector2 direction;
    public GameObject muzzelFlash;
    public Text specialText;
    public int specialAmmo;
    
    // Start is called before the first frame update
    void Start()
    {
        //get componets
        rb2d = this.GetComponent<Rigidbody2D>();
        muzzelFlash.SetActive(false);

        //set up
        specialAmmo = 0;
        specialText.text = specialAmmo.ToString();
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
                    
                }
            }
        }
    }

    //enemy overlapped player
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            //stop game
            Time.timeScale = 0;

            //open menu
            gameOverMenu.SetActive(true);
        }
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

    public void EnemyKilled()
    {
        //add ammo
        if(specialAmmo < 5)
        {
            specialAmmo++;
        }

        //update hud
        specialText.text = specialAmmo.ToString();
    }

    public void FriendlySpawned(int cost)
    {
        //dec points
        specialAmmo -= cost;

        //update hud
        specialText.text = specialAmmo.ToString();
    }
}
