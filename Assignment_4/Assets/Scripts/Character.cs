using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character
{
    public string description = "NA";

    //weapon
    public float range;
    public int damage;
    public int health;

    //weapon
    public virtual float GetRange()
    {
        return range;
    }

    public virtual int GetDamage()
    {
        return damage;
    }
    
    //class
    public abstract int GetHealth();

    public abstract float GetSpeed();
}