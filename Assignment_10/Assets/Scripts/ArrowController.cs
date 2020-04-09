/*
    * Jacob Cohen
    * ArrowController.cs
    * Assignment #10
    * controls the arrow
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    //variables
    GameObject[] gos;
    GameObject closest = null;
    float distance = Mathf.Infinity;
    Vector3 position;



    // Update is called once per frame
    void LateUpdate()
    {
        //get enemies
        gos = GameObject.FindGameObjectsWithTag("PickUp");

        //get position
        position = transform.position;

        //rest
        closest = null;
        distance = Mathf.Infinity;

        //check
        if(gos != null)
        {
            //loop through enemies
            foreach (GameObject item in gos)
            {
                //check to see if active
                if(item.activeInHierarchy == true)
                {
                    Vector3 diff = item.transform.position - position;
                    float curDistance = diff.sqrMagnitude;
                    if (curDistance < distance)
                    {
                        closest = item;
                        distance = curDistance;
                    }
                }
            }
        }

        //check
        if(closest != null)
        {
            //look
            this.transform.up = (closest.transform.position - transform.position) * -1;
        }
    }
}
  
