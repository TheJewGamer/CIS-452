/*
    * Jacob Cohen
    * PlayerController.cs
    * Assignment #7
    * controls player movement and placing the teleporter
*/

using UnityEngine;

public class PlayerController : MonoBehaviour 
{

     //variables
    public GameObject gameOverMenu;
    public GameObject winMenu;
    private Vector2  movement;
    private Rigidbody2D rb2d;
    private Vector2 direction;
    public float speed = 4f;

    private void Start() 
    {
        //get componets
        rb2d = this.GetComponent<Rigidbody2D>();
    }

    public GameObject PlaceTeleporter()
    {
        //var
        GameObject prefab = Resources.Load<GameObject>("teleporter");

        //spawn at players location
        prefab = Instantiate(prefab, this.gameObject.transform.position, this.gameObject.transform.rotation);

        //done
        return prefab;
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
}