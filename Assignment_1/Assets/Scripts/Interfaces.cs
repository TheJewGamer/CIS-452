/*
* Jacob Cohen
* Interfaces.cs
* Assignment 1
* Contains the interfaces that are implemented by the developer and manager classes
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assignment_1
{
    public interface CanHaveBreakdown
    {
        void Breakdown();
    }

    public interface CanQuit
    {
        void Quit();
    }
}