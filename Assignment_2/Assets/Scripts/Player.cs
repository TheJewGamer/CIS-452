/*
    * Jacob Cohen
    * Player.cs
    * Assignment #2
    * Controls the player
*/

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

    //hud
    public Text scoreText;
    public GameObject gameOverMenu;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject hitEffect;
    public static Vector2 direction;

    //weapons
    public GameObject pistolScript;
    public GameObject machineGunScript;

    //stuff
    public ChangeWeaponBehavior ChangeWeaponBehavior{get; set;}

    public virtual void DoChangeWeapon() 
    {
        //change sprite
        ChangeWeaponBehavior.ChangeWeapon();
    }

    // Start is called before the first frame update
    void Start()
    {
        //get rigibody
        rb2d = GetComponent<Rigidbody2D>();

        //hud
        heart1.SetActive(true);
        heart2.SetActive(true);
        heart3.SetActive(true);
        hitEffect.SetActive(false);
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

            //switch weapons
            if(Input.GetKeyDown(KeyCode.Alpha1) == true)
            {
                //script changes
                pistolScript.SetActive(true);
                machineGunScript.SetActive(false);

                Destroy(GetComponent<ChangeWeaponBehavior>());
                ChangeWeaponBehavior = gameObject.AddComponent<ChangeWeaponPistol>();
                //call
                DoChangeWeapon();
            }

            if(Input.GetKeyDown(KeyCode.Alpha2) == true)
            {
                //script changes
                pistolScript.SetActive(false);
                machineGunScript.SetActive(true);

                Destroy(GetComponent<ChangeWeaponBehavior>());
                ChangeWeaponBehavior = gameObject.AddComponent<ChangeWeaponMachineGun>();
                //call
                DoChangeWeapon();
            }
        }
    }

    void LateUpdate()
    {
        //actually moving player here
        rb2d.MovePosition(rb2d.position + movement * speed * Time.fixedDeltaTime);
    }

    //zombie overlapped player
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "enemy")
        {
            //feedback
            StartCoroutine(hitFlash());

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

    private IEnumerator hitFlash()
    {
        //enable
        hitEffect.SetActive(true);

        yield return new WaitForSeconds(.05f);

        hitEffect.SetActive(false);
    }
}
