using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    //variable
    public GameObject winMenu;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") == true)
        {
            //pause game
            Time.timeScale = 0;

            //open menu
            winMenu.SetActive(true);
        }
    }
}
