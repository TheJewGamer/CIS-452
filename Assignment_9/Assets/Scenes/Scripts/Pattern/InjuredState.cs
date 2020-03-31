using UnityEngine;
using System.Collections;

public class InjuredState : PlayerStates 
{
    //variables
    private PlayerController controller;

    public InjuredState(PlayerController input)
    {
        controller = input;
    }

    public void RecoverFromInjury()
    {
        //set stats to normal
    }

    public void RecoverFromTried()
    {
        Debug.Log("Wrong state");
    }
    public void Normal()
    {
        Debug.Log("Wrong state");
    }
}