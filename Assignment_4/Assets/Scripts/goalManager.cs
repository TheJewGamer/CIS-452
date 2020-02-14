/*
    * Jacob Cohen
    * goalManager.cs
    * Assignment #4
    * controls the goal and win state
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalManager : MonoBehaviour
{
    public GameObject winMenu;

    //player reached the end
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Time.timeScale = 0;

            //open menu
            winMenu.SetActive(true);

        }
    }
}
