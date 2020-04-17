/*
    * Jacob Cohen
    * GreenPickup.cs
    * Assignment #11
    * controls the green pickup
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPickup : MonoBehaviour
{
    private Rigidbody2D rb2d;

    private void Start() 
    {
        rb2d = this.gameObject.GetComponent<Rigidbody2D>();    
    }

    public void PickedUp(PickUpManager manager)
    {
        //add points
        manager.points += 10;

        //remove gameobject
        Destroy(this.gameObject);
    }

    public void Action()
    {
        //spin
        rb2d.MoveRotation(rb2d.rotation + 1 * 50 * Time.fixedDeltaTime);
    }
}
