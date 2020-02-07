/*
    * Jacob Cohen
    * IObserver.cs
    * Assignment #3
    * Implents the pattern used by grunts
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver
{
    void UpdateStatus(bool siteAlert, float distance);
}