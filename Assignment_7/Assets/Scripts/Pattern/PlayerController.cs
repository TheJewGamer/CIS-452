/*
    * Jacob Cohen
    * PlayerController.cs
    * Assignment #6
    * controls the player
*/

using System.Collections;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    //variables
    private Vector2  movement;
    private Rigidbody2D rb2d;
    public GameObject gameOverMenu;
    public GameObject winMenu;
    public Teleporter teleporter;
    public float speed = 4f;
    private Vector2 direction;
    
    // Start is called before the first frame update
    private void Start()
    {
        //get componets
        rb2d = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        //movement
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        //actually moving player here
        rb2d.MovePosition(rb2d.position + movement * speed * Time.fixedDeltaTime);
    }

    private void LateUpdate() 
    {
        //look towards mouse
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.right = direction;    

        //put down teleporter
        if(Input.GetKeyDown(KeyCode.F) == true)
        {  
            //var
            GameObject prefab = Resources.Load<GameObject>("teleporter");

            //spawn at players location
            prefab = Instantiate(prefab, this.gameObject.transform.position, this.gameObject.transform.rotation);

            //debug
            Debug.Log("placed teleporter");

            //call
            teleporter.Execute(prefab);
        }

        //teleport
        if(Input.GetKeyDown(KeyCode.Space) == true)
        {
            //var
            GameObject temp;

            //call
            temp = teleporter.Undo();

            //check
            if(temp != null)
            {
                //teleport
                this.gameObject.transform.position = temp.transform.position;

                //delete teleporter
                Destroy(temp);

                //debug
                Debug.Log("teleported");
            }
            else
            {
                //nothing to teleport to

                //debug
                Debug.Log("No teleporter available");
            }

        }
    }
}
