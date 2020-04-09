/*
    * Jacob Cohen
    * PickupController.cs
    * TUTPickupController #10
    * controls the pickup used in the tutorial 
*/

using UnityEngine;

public class TUTPickupController : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other) 
    {
        //check
        if(other.tag == "Player" && this.gameObject.activeInHierarchy)
        {
            //disable
            Destroy(this.gameObject);
        }    
    }
}
