using UnityEngine;

public class TiredState : PlayerStates 
{
    //variable
    private PlayerController controller;

    public TiredState(PlayerController input)
    {
        controller = input;
    }

    public void RecoverFromInjury()
    {
        Debug.Log("Wrong state");
    }

    public void RecoverFromTried()
    {
        //set stats to normal
    }
    public void Normal()
    {
        Debug.Log("Wrong state");
    }
}