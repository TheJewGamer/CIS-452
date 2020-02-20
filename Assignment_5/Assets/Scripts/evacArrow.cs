/*
    * Jacob Cohen
    * evacArrow.cs
    * Assignment #5
    * controls the evac arrow
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evacArrow : MonoBehaviour
{
    //variables
    public Transform evacZone;

    private void Start() 
    {
        this.gameObject.SetActive(false);    
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //look at evac zone
        this.transform.right = (evacZone.transform.position - transform.position);
    }
}
