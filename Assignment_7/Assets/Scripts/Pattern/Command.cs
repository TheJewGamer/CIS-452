/*
    * Jacob Cohen
    * Command.cs
    * Assignment #7
    * controls the pattern
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Command
{
   void Execute();
   void Undo();
}
