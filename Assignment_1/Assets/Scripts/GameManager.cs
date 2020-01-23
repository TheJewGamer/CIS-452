/*
* Jacob Cohen
* Worker.cs
* Assignment 1
* Tests the parts in the Worker.cs and Interface.cs files
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assignment_1
{
    public class GameManager : MonoBehaviour
    {
        //variables
        public Worker _developer;
        public Worker _manager;

        public List<Worker> _workerList = new List<Worker>();
        public List<CanQuit> _interfaceList = new List<CanQuit>();


        // Start is called before the first frame update
        void Start()
        {
            ///PART 1

            //Developer
            Debug.Log("Create Developer");
            _developer = new Developer();
            _developer.Job();

            //Manager
            Debug.Log("Create Manager");
            _manager = new Manager();
            _manager.Job();

            ///PART 2

            //add to list
            for(int i = 0; i < 2; i++)
            {
                _workerList.Add(new Developer());
                _workerList.Add(new Manager());
            }

            //PART 4
            
            //add to list
            for(int i = 0; i < 2; i++)
            {
                _interfaceList.Add(new Developer());
                _interfaceList.Add(new Manager());
            }

            ///PART 5

            //add new Boss class to lists
            _workerList.Add(new Boss());
            _interfaceList.Add(new Boss());
        }

        // Update is called once per frame
        void Update()
        {
            ///PART 3 

            //check for input
            if(Input.GetKeyDown(KeyCode.Alpha1) == true)
            {
                //loop
                foreach(Worker item in _workerList)
                {
                    //check
                    if(item == null)
                    {
                        //done
                        break;
                    }
                    else
                    {
                        //call
                        item.Job();
                    }
                }
            }

            ///Part 4
            if(Input.GetKeyDown(KeyCode.Alpha2) == true)
            {
                //loop
                foreach(CanQuit item in _workerList)
                {
                    //check
                    if(item == null)
                    {
                        //done
                        break;
                    }
                    else
                    {
                        //call
                        item.Quit();
                    }
                }
            }
        }
    }
}
