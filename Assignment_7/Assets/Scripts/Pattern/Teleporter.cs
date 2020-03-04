using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Teleporter : MonoBehaviour, Command
{
    public static Stack<GameObject> teleporters;

    public Teleporter()
    {
        teleporters = new Stack<GameObject>();
    }

    //put down teleporter
    public void Execute(GameObject input)
    {
        //add to the stack
        teleporters.Push(input);
    }

    //teleport
    public Transform Undo()
    {
        //var
        GameObject temp;
        Transform location = null;

        //check
        if(teleporters.Count > 0)
        {
            //get most recent teleporter
            temp = teleporters.Pop();

            //get transform
            location = temp.transform;

            //delete teleporter
            Destroy(temp);
        }
        else
        {
            location = null;
        }

        //done
        return location;
    }
}