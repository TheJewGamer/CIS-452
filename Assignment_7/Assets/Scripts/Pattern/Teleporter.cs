/*
    * Jacob Cohen
    * Teleporter.cs
    * Assignment #7
    * controls the actual placing and teleporting
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Teleporter : Command
{
    private static Stack<GameObject> teleporters;
    
    //pattern
    private PlayerController player;

    public Teleporter(PlayerController input)
    {
        this.player = input;
        teleporters = new Stack<GameObject>();
    }

    //put down teleporter
    public void Execute()
    {
        //check
        if(teleporters.Count < 3)
        {
            //add to the stack
            teleporters.Push(player.PlaceTeleporter());
        }
        else
        {
            //out of teleporters
        }
            
    }

    //teleport
    public void Undo()
    {
        //check
        if(teleporters.Count > 0)
        {
            //get most recent teleporter
            player.gameObject.transform.position = teleporters.Pop().transform.position;
        }
    }
}