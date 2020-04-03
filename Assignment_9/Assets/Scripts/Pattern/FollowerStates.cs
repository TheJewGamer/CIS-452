/*
    * Jacob Cohen
    * FollowerStates.cs
    * Assignment #9
    * Creates the states the follower can use
*/

using UnityEngine;

public abstract class FollowerStates : MonoBehaviour 
{
    public abstract void StartFollowing();
    public abstract void StopFollowing();
    public abstract void CalmDown();
    public abstract void Fed();
    public abstract void Scared();
    public abstract void Init();
    
}