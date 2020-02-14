/*
    * Jacob Cohen
    * ClassSpy.cs
    * Assignment #4
    * Sets up the spy class
*/

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