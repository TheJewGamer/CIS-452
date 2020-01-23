/*
* Jacob Cohen
* Worker.cs
* Assignment 1
* Contains the abstract Worker class and the Developer, Manager, Boss classes which inherit from it
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assignment_1
{
    public abstract class Worker
    {
        public abstract void Job();

        public void Talk()
        {
            //print
            Debug.Log("Work, Work, Work.");
            //add text bubble that displays text
        }
    }

    public class Manager : Worker, CanHaveBreakdown, CanQuit
    {
        //variable
        private int approval;

        public override void Job()
        {
            //add jobs to chose from
            Debug.Log("The Manager's current Job has been set.");
            //add text bubble that displays text
        }

        public void Breakdown()
        {
            //remove manager from current job and prevent them from being assigned to another one
            Debug.Log("The Manager is currently having a breakdown and is not able to work.");
            //add text bubble that displays text
            //set time that breakdown lasts
        }
        
        public void Quit()
        {
            Debug.Log("This manager has had enough and quits.");
            //add text bubble displays text
            //remove manager from game
        }
    }

    public class Developer : Worker, CanQuit, CanHaveBreakdown
    {
        //variable
        private int happiness;

        public override void Job()
        {
            //add jobs to chose from
            Debug.Log("The Developer's current Job has been set.");
            //add text bubble that displays text
        }

        public void Quit()
        {
            Debug.Log("This developer has had enough and quits.");
            //add text bubble displays text
            //remove developer from game
        }

        public void Breakdown()
        {
            //remove developer from current job and prevent them from being assigned to another one
            Debug.Log("The Developer is currently having a breakdown and is not able to work.");
            //add text bubble that displays text
            //set time that breakdown lasts
        }
    }

    public class Boss : Worker, CanQuit, CanHaveBreakdown
    {
        //variable
        private int salary;

        public override void Job()
        {
            //add jobs to choose from
            Debug.Log("The Boss's current Job has been set");
            //add text bubble that displays text
        }

        public void Quit()
        {
            Debug.Log("The Boss has had enough and quits.");
            //add text bubble displays text
            //remove boss from game
        }

        public void Breakdown()
        {
            //remove boss from current job and prevent them from being assigned to another one
            Debug.Log("The Boss is currently having a breakdown and is not able to work.");
            //add text bubble that displays text
            //set time that breakdown lasts
        }
    }
}
