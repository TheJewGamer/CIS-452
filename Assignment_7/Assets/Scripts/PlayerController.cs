/*
    * Jacob Cohen
    * PlayerController.cs
    * Assignment #7
    * controls player movement
*/

using UnityEngine;
using System.Collections.Generic;

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