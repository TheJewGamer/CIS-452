/*
    * Jacob Cohen
    * PlayerController.cs
    * Assignment #7
    * controls destroying the teleporter after the player uses it
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporterController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        //check
        if(other.gameObject.tag == "Teleporting")
        {
            //switch
            other.gameObject.tag = "Player";

            //destroy
            Destroy(this.gameObject);
        }    
    }
}
