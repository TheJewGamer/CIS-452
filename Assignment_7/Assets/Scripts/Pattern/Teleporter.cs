using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Teleporter : MonoBehaviour, Command
{
    private static Stack<GameObject> teleporters;

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
    public GameObject Undo()
    {
        //var
        GameObject temp = null;

        //check
        if(teleporters.Count > 0)
        {
            //get most recent teleporter
            temp = teleporters.Pop();
        }
        else
        {
            temp = null;
        }

        //done
        return temp;
    }
}