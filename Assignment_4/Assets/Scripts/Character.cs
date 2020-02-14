using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character
{
    public int damage;

    public virtual int GetDamage()
    {
        return damage;
    }
    
    //class
    public abstract int GetHealth();

    public abstract float GetSpeed();
}