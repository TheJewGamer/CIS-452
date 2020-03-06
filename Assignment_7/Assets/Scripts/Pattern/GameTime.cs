/*
    * Jacob Cohen
    * GameTime.cs
    * Assignment #7
    * controls the ability to slow down time
*/

using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameTime : Command  
{
    //vars
    private GameTimeManager manager;
    public Stack<float> timeSetting;
    private Text display;
    private float count;

    public GameTime(GameTimeManager input)
    {
        //setup
        this.manager = input;
        timeSetting = new Stack<float>();
        count = 1;
        display = GameObject.Find("Text-TimeCount").GetComponent<Text>();
    }

    public void Execute()
    {
        //check
        if(Time.timeScale > .5f)
        {
            //dec
            count -= .1f;

            //update
            display.text = count.ToString("F1");

            //add to the stack
            timeSetting.Push(manager.SlowTime());
        }
    }

    public void Undo()
    {
        if(timeSetting.Count > 0)
        {
            //inc
            count += .1f;

            //update
            display.text = (count).ToString("F1");
            
            //pop time
            Time.timeScale = timeSetting.Pop() + .1f;
        }
    }
}