/*
    * Jacob Cohen
    * GoalController.cs
    * Assignment #9
    * controls the goal
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    //variable
    public GameObject winMenu;

    private void Start() 
    {
        winMenu.SetActive(false);    
    }

    public void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Follower")
        {
            //win
            winMenu.SetActive(true);

            //pause
            Time.timeScale = 0;
        }    
    }
}
