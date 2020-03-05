/*
    * Jacob Cohen
    * GameTime.cs
    * Assignment #7
    * controls the ability to slow down time
*/

using UnityEngine;
using System.Collections.Generic;

public class GameTime : Command  
{
    //vars
    private GameTimeManager manager;
    Stack<float> timeSetting;

    public GameTime(GameTimeManager input)
    {
        //setup
        this.manager = input;
        timeSetting = new Stack<float>();
    }

    public void Execute()
    {
        //check
        if(Time.timeScale > .5f)
        {
            //add to the stack
            timeSetting.Push(manager.SlowTime());
        }
    }

    public void Undo()
    {
        if(timeSetting.Count > 0)
        {
            //pop time
            Time.timeScale = timeSetting.Pop() + .1f;

            Debug.Log("Speed time back up" + Time.timeScale);
        }
    }
}