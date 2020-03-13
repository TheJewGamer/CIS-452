/*
    * Jacob Cohen
    * TableController.cs
    * Assignment #8
    * controls the tables and if they are being used or not
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableController : MonoBehaviour
{
    private GameObject food;
    private GameObject table;
    public bool inUse;

    // Start is called before the first frame update
    void Start()
    {
        //set up
        inUse = false;
        food = this.gameObject.transform.GetChild(0).gameObject;
        table = this.gameObject.transform.GetChild(1).gameObject;
    }
}
