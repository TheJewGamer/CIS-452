/*
    * Jacob Cohen
    * PlayerCommandInputManager.cs
    * Assignment #7
    * controls the input detection and undo for all commands
*/

using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


public class PlayerCommandInputManager : MonoBehaviour
{
    //pattern 1
    public TeleporterManager teleporterManager;
    private Teleporter teleporter;

    //pattern 2
    public GameTimeManager gameTimeManger;
    private GameTime gameTime;

    //main
    private Stack<Command> commandHistory;
    
    
    // Start is called before the first frame update
    private void Start()
    {
        //pattern
        teleporter = new Teleporter(teleporterManager);
        gameTime = new GameTime(gameTimeManger);

        //setup
        commandHistory = new Stack<Command>();
    }

    private void LateUpdate() 
    { 

        //put down teleporter
        if(Input.GetKeyDown(KeyCode.F) == true)
        {
            //add to history
            commandHistory.Push(teleporter);

            //call
            teleporter.Execute();

        }
        
        if(Input.GetKeyDown(KeyCode.R) == true)
        {
            //add to history
            commandHistory.Push(gameTime);

            //call
            gameTime.Execute();         
        }

        //teleport
        if(Input.GetKeyDown(KeyCode.Space) == true)
        {
            //check
            if(commandHistory.Count > 0)
            {
                //call most recent undo command
                commandHistory.Pop().Undo();
            }
        }
    }
}
