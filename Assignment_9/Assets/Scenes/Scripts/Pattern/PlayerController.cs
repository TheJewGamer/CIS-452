using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //pattern stuff
    public PlayerStates normalState {get; set;}
    public PlayerStates injuredState {get; set;}
    public PlayerStates tiredState {get; set;}
    public PlayerStates currentState {get; set;}

    //stats
    int health;
    float speed;
    int damage;

    // Start is called before the first frame update
    void Start()
    {
        injuredState = new InjuredState(this);
        tiredState = new TiredState(this);
        normalState = new NormalState(this);
    }

    // Update is called once per frame
    void Update()
    {
        //input

    }
}
