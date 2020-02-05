using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISubject
{
    void RegisterObserver(IObserver ob);
    void RemoveObserver(IObserver ob);
    void NotifyObservers();
}