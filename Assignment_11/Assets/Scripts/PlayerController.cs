/*
    * Jacob Cohen
    * PlayerController.cs
    * Final Project
    * controls the player
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //variables
    public bool stunned;
    private Rigidbody2D rb2d;
    private float maxVelocity = 1f;
    private float rotationSpeed = 1f;
    public GameObject warningText;


    // Start is called before the first frame update
    private void Start()
    {
        //unpause
        Time.timeScale = 1;

        //get componets
        rb2d = this.GetComponent<Rigidbody2D>();

        //set up
        stunned = false;
        warningText.SetActive(false);
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        //make sure not stuned
        if(!stunned)
        {
           float yAxis = Input.GetAxis("Vertical");
           float xAxis = Input.GetAxis("Horizontal");

           ThrustForward(yAxis);
           Rotate(transform, xAxis * -rotationSpeed);
           ClampVelocity();
        }
    }

    public IEnumerator Stunned()
    {
        //true
        stunned = true;
        warningText.SetActive(true);
        

        yield return new WaitForSecondsRealtime(1);

        //false
        stunned = false;
        warningText.SetActive(false);
    }

    private void ClampVelocity()
    {
        float x = Mathf.Clamp(rb2d.velocity.x, -maxVelocity, maxVelocity);
        float y = Mathf.Clamp(rb2d.velocity.y, -maxVelocity, maxVelocity);

        rb2d.velocity = new Vector2 (x,y);
    }

    private void ThrustForward(float input)
    {
        Vector2 force = transform.up * input;

        rb2d.AddForce(force);
    }

    private void Rotate(Transform tInput, float input)
    {
        tInput.Rotate(0,0,input);
    }
}


