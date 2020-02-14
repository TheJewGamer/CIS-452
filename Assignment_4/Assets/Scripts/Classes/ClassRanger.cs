using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassRanger : Character
{
    //base health
    public override int GetHealth()
    {
        return 7;
    }

    //base speed
    public override float GetSpeed()
    {
        return 3f;
    }

    //base damage
    public override int GetDamage()
    {
        return 5;
    }
}