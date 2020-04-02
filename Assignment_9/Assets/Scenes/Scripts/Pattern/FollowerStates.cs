using UnityEngine;

public abstract class FollowerStates : MonoBehaviour 
{
    public abstract void StartFollowing();
    public abstract void StopFollowing();
    public abstract void CalmDown();
    public abstract void Fed();
    public abstract void Scared();
    
}