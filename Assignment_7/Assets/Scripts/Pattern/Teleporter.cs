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
    GameObject player;

    //pattern
    private TeleporterManager manager;

    public Teleporter(TeleporterManager input)
    {
        this.manager = input;
        teleporters = new Stack<GameObject>();
        player = GameObject.Find("player");
    }

    //put down teleporter
    public void Execute()
    {
        //check
        if(teleporters.Count < 3)
        {
            //add to the stack
            teleporters.Push(manager.PlaceTeleporter());
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
            Debug.Log("Teleported to most recent Teleporter");

            player.tag = "Teleporting";

            //get most recent teleporter
            player.transform.position = teleporters.Pop().transform.position;
        }
    }
}