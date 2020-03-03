﻿/*
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
            teleporter.Execute(this.gameObject.transform);
        }

        //teleport
        if(Input.GetKeyDown(KeyCode.Space) == true)
        {
            this.gameObject.transform.position = teleporter.Undo(this.gameObject.transform).position;
        }
    }
}
