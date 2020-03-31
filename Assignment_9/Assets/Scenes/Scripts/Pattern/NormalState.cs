using UnityEngine;

public class NormalState : PlayerStates 
{
    //variable
    private PlayerController controller;

    public NormalState(PlayerController input)
    { 
        controller = input;
    }

    public void RecoverFromInjury()
    {
        Debug.Log("Wrong state");
    }

    public void RecoverFromTried()
    {
        Debug.Log("Wrong state");
    }
    public void Normal()
    {
        //normal stats
    }
}