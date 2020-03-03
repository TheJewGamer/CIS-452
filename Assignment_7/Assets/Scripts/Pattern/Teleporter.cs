using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Teleporter : MonoBehaviour, Command
{
    public static Stack<Transform> teleporters = new Stack<Transform>();

    public Teleporter()
    {

    }

    //put down teleporter
    public void Execute()
    {
        //add to the stack
        teleporters.Push(this.gameObject.transform);
    }

    //teleport
    public Transform Undo()
    {
        //var
        Transform location = this.gameObject.transform;

        //get most recent teleporter
        location = teleporters.Pop();

        //done
        return location;
    }
}