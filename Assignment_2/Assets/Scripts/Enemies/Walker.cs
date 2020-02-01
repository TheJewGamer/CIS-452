/*
    * Jacob Cohen
    * Walker.cs
    * Assignment #2
    * Strategy Pattern class for the enemy blobs
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Walker : Enemy
{
    public void Awake()
    {
        //set movement to walk
        MovementBehavior = gameObject.AddComponent<MovementWalk>();
    }
}