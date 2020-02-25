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
    private int health = 10;
    private Vector2 direction;
    public GameObject hitEffect;
    public GameObject muzzelFlash;
    public Text healthText;
    public Text specialText;
    public int specialAmmo;
    public GameObject walkerPrefab;
    public GameObject runnerPrefab;
    private GameObject currentSpawn;
    public CharacterCreator characterCreator;
    
    // Start is called before the first frame update
    void Start()
    {
        //get componets
        rb2d = this.GetComponent<Rigidbody2D>();
        muzzelFlash.SetActive(false);

        //set up
        specialAmmo = 0;
        specialText.text = specialAmmo.ToString();
        healthText.text = health.ToString();
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

        //spawn friendly walker
        if(Input.GetKeyDown(KeyCode.Alpha1) == true)
        {
            //check
            if(specialAmmo >= 5)
            {
                //spawn friendly enemy

                //dec
                specialAmmo -= 5;

                //update hud
                specialText.text = specialAmmo.ToString();
            }
        }

        //spawn friendly runner
        if(Input.GetKeyDown(KeyCode.Alpha2) == true)
        {
            //check
            if(specialAmmo >= 3)
            {
                //spawn friendly runner
                currentSpawn = Instantiate(runnerPrefab, this.transform.position, this.transform.rotation);

                //dec
                specialAmmo -= 3;

                //update hud 
                specialText.text = specialAmmo.ToString();
            }
        }
    }

    //enemy overlapped player
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            //get damage and update health
            health -= other.GetComponent<Character>().damage;

            //destory enemy that hit player
            Destroy(other.gameObject);

            //update health display
            healthText.text = health.ToString();
            
            //flash hit
            StartCoroutine(hitFlash());

            //check
            if(health <= 0)
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
}
