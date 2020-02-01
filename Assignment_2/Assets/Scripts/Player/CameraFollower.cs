/*
    * Jacob Cohen
    * CameraFollower.cs
    * Assignment #2
    * Controls the camera so it follows the player
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    //varaibles
    public GameObject player;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        //set offset
        offset = this.transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;        
    }
}
