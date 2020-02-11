using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //variables
    int health = 3;

    public void Attacked()
    {
        //dec
        health--;

        //check
        if(health <= 0)
        {
            //dead
            Destroy(gameObject);
        }
    }
}