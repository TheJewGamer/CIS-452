/*
    * Jacob Cohen
    * evacZone.cs
    * Assignment #5
    * controls the evac zone
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evacZone : MonoBehaviour
{
    //variables
    public GameObject winMenu;

    private void Start() 
    {
        winMenu.SetActive(false);    
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        //check to make sure its player
        if(other.CompareTag("Player"))
        {
            //pause game
            Time.timeScale = 0;

            //load menu
            winMenu.SetActive(true);
        }    
    }
}
