using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassSpy : Character
{
    //base health
    public override int GetHealth()
    {
        return 5;
    }

    //base speed
    public override float GetSpeed()
    {
        return 5f;
    }

    //base damage
    public override int GetDamage()
    {
        return 3;
    }
} 