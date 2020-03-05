/*
    * Jacob Cohen
    * TeleportPlayer.cs
    * Assignment #7
    * controls the input detection  for placing and teleporting
*/

using System.Collections;
using UnityEngine;


public class TeleportPlayer : MonoBehaviour
{
    //pattern
    public PlayerController player;
    private Command teleporter;
    
    // Start is called before the first frame update
    private void Start()
    {
        //pattern
        teleporter = new Teleporter(player);
    }

    private void LateUpdate() 
    { 

        //put down teleporter
        if(Input.GetKeyDown(KeyCode.F) == true)
        {  
            //debug
            Debug.Log("placed teleporter");

            //call
            teleporter.Execute();
        }

        //teleport
        if(Input.GetKeyDown(KeyCode.Space) == true)
        {
            //switch tag
            player.gameObject.tag = "Teleporting";

            //call
            teleporter.Undo();
        }
    }
}
