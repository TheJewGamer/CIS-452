/*
    * Jacob Cohen
    * GameTimeManager.cs
    * Assignment #7
    * controls slowing down time
*/

using UnityEngine;

public class GameTimeManager : MonoBehaviour 
{
    //vars
    private float timeHolder; 

    public float SlowTime()
    {
        Time.timeScale = timeHolder = Time.timeScale -.1f;

        Debug.Log("Slowed Time down: " + Time.timeScale);

        return timeHolder;
    }
}