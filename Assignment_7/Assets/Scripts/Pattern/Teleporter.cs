using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Teleporter : MonoBehaviour, Command
{
    public static Stack<Transform> teleporters;

    public Teleporter()
    {
        teleporters = new Stack<Transform>();
    }

    //put down teleporter
    public void Execute(Transform player)
    {
        //add to the stack
        teleporters.Push(player);
    }

    //teleport
    public Transform Undo(Transform player)
    {
        //var
        Transform location;

        //get most recent teleporter
        location = teleporters.Pop();

        //done
        return location;
    }
}