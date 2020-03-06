/*
    * Jacob Cohen
    * Teleporter.cs
    * Assignment #7
    * controls the actual placing and teleporting
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Teleporter : Command 
{
    private static Stack<GameObject> teleporters;
    private GameObject player;
    private Text display;
    private int count;

    //pattern
    private TeleporterManager manager;

    public Teleporter(TeleporterManager input)
    {
        this.manager = input;
        teleporters = new Stack<GameObject>();
        player = GameObject.Find("player");
        display = GameObject.Find("Text-TeleporterCount").GetComponent<Text>();
        count = 3;
    }

    //put down teleporter
    public void Execute()
    {
        //check
        if(teleporters.Count < 3)
        {
            //dec
            count--;

            //update
            display.text = count.ToString();

            //add to the stack
            teleporters.Push(manager.PlaceTeleporter());
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

            //inc
            count++;

            //update
            display.text = count.ToString();

            //get most recent teleporter
            player.transform.position = teleporters.Pop().transform.position;
        }
    }
}