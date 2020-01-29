using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //player
    private Rigidbody2D rb2d;
    private float speed = .5f;
    private int health = 3;
    private Vector2 movement;

    //weapon
    public Transform barrel;
    public GameObject reloadingText;
    private int reloadTimeTatical = 1;
    private int reloadTimeEmpty = 2;
    private int magSize = 16;
    private float fireRate = .01f;
    private int currentAmmo;
    private bool reloading = false;
    private float attackWait;

    Vector2 direction;

    //hud
    public Text currentText;
    public Text scoreText;
    public GameObject gameOverMenu;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    

    // Start is called before the first frame update
    void Start()
    {
        //get rigibody
        rb2d = GetComponent<Rigidbody2D>();

        //assign ammo
        currentAmmo = magSize;

        //hud update
        currentText.text = currentAmmo.ToString();
        reloadingText.SetActive(false);
        heart1.SetActive(true);
        heart2.SetActive(true);
        heart3.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        //movement
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        
        //make sure game isn't over
        if(Time.timeScale != 0)
        {
            //look towards mouse
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
            transform.right = direction * -1;
        }
        
        //reload
        if(Input.GetButton("Reload") == true)
        {
            //call
            Reload();
        }

        //shoot
        if(Input.GetMouseButtonDown(0) == true)
        {
            //call
            Attack();
        }
    }

    void LateUpdate()
    {
        //actually moving player here
        rb2d.MovePosition(rb2d.position + movement * speed * Time.fixedDeltaTime);
    }

    //shoot weapon
    public void Attack()
    {
        //check for ammo, fireRate, and reloading
        if(!reloading && currentAmmo > 0 && Time.time > attackWait)
        {
            //fireRate
            attackWait = Time.time + fireRate;

            //ammo
            currentAmmo--;

            //hud update
            currentText.text = currentAmmo.ToString();

            //raycast
            RaycastHit2D hit = Physics2D.Raycast(barrel.transform.position, direction);

            //check to see what was hit
            if(hit.collider !=null)
            {
                //enemy hit
                if(hit.collider.CompareTag("enemy"))
                {
                    //testing
                    Debug.Log("hit");

                    //notify
                    hit.transform.SendMessageUpwards("Shot");
                }
            }

            Debug.Log("miss");
        }
        //out of ammo
        else
        {
            //do nothing for now
        }

    }

    private IEnumerator Reloading()
    {
        //variable
        int waitTime;

        //prevent shooting/ double reload
        reloading = true;

        //hud update
        reloadingText.SetActive(true);

        //tactical reload
        if(currentAmmo > 0)
        {
            //set wait time
            waitTime = reloadTimeTatical;
        }
        //empty reload
        else
        {
            //set wait time
            waitTime = reloadTimeEmpty;
        }

        //wait
        yield return new WaitForSeconds(waitTime);

        //give ammo
        currentAmmo = magSize;

        //update hud
        currentText.text = currentAmmo.ToString();

        //done reloading
        reloading = false;

        //hud update
        reloadingText.SetActive(false);
    }

    //reload
    private void Reload()
    {
        //check to make sure you can
        if(currentAmmo < magSize && !reloading)
        {
            StartCoroutine(Reloading());
        }
    }

    //zombie overlapped player
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "enemy")
        {
            //destory enemy that hit player
            Destroy(other.gameObject);

            //subtract health
            health--;

            //hud update
            switch (health)
            {
                case 2:
                heart3.SetActive(false);
                break;

                case 1:
                heart2.SetActive(false);
                break;

                case 0:
                heart1.SetActive(false);
                GameOver();
                break;

                default:
                Debug.Log("Error");
                break;
            }            
        }
    }

    public void Score(int points)
    {
        //update score hud
        scoreText.text = (int.Parse(scoreText.text.ToString()) + points).ToString(); 
    }

    private void GameOver()
    {
        //pause game
        Time.timeScale = 0;

        //display menu
        gameOverMenu.SetActive(true);
    }
}
