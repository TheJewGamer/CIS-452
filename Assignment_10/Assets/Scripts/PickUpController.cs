/*
    * Jacob Cohen
    * PickupController.cs
    * Assignment #10
    * controls the player
*/

using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other) 
    {
        //check
        if(other.tag == "Player")
        {
            //call
            other.gameObject.GetComponent<PlayerController>().PickUp();

            //disable
            this.gameObject.SetActive(false);
        }    
    }
}
