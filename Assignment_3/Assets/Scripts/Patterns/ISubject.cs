/*
    * Jacob Cohen
    * ISubject.cs
    * Assignment #3
    * Implements the pattern used by the watcher
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISubject
{
    void RegisterObserver(IObserver ob);
    void RemoveObserver(IObserver ob);
    void NotifyObservers();
}