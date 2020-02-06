using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //input
        if(Input.GetKeyDown(KeyCode.F) == true)
        {
            Debug.Log("stab");

            //check
            if(other.CompareTag("Grunt") == true)
            {
                //call
                other.SendMessageUpwards("Stabbed");
            }
        }
    }
}
