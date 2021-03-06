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
            //var
            GameObject temp;

            //inc
            count++;

            //update
            display.text = count.ToString();

            //hold
            temp = teleporters.Pop();

            //teleport
            player.transform.position = temp.transform.position;

            //'Delete'
            temp.SetActive(false);
        }
    }
}