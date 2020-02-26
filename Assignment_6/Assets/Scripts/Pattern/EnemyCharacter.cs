/*
    * Jacob Cohen
    * EnemyCharacter.cs
    * Assignment #6
    * creates an enemy
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : CharacterCreator
{
    //vars
    private GameObject prefab;

    public override GameObject CreateCharacter(string type)
    {
        switch (type)
        {
            case "runner":
                //spawn runner
                prefab = GameObject.Find("Runner");
                break;
            case "walker":
                //spawn walker
                prefab = GameObject.Find("Walker");
                break;
            default:
                Debug.Log("there is an issue");
                break;
        }

        //done
        return prefab;
    }
}