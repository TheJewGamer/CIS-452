using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //variables
    public Character character;
    private Vector2  movement;
    private Rigidbody2D rb2d;
    public GameObject gameOverMenu;
    public GameObject winMenu;
    private int health;

    // Start is called before the first frame update
    void Start()
    {
        //get componets
        rb2d = this.GetComponent<Rigidbody2D>();
        health = character.GetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        //Attack
        if(Input.GetMouseButtonDown(0) == true)
        {
            //raytrace
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, character.GetRange());

            //check
            if(hit.collider != null)
            {
                if(hit.collider.CompareTag("Enemy") == true)
                {
                    //call
                    hit.collider.SendMessage("Attacked");
                }
            }
        }
    }

    void LateUpdate()
    {
        //actually moving player here
        rb2d.MovePosition(rb2d.position + movement * character.GetSpeed() * Time.fixedDeltaTime);
    }

    public void SetClass(string input)
    {
        switch(input)
        {
            case "Ranger":
                this.character = new ClassRanger();
                break;
            case "Spy":
                this.character = new ClassSpy();
                break;
            default:
                Debug.Log("No class found");
                break;
        }
    }
}
