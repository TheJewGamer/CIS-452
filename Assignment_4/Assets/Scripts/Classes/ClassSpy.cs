using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassSpy : Character
{
    public ClassSpy()
    {
        this.description = "Spy";
    }

    public override int GetHealth()
    {
        return this.GetHealth() + 3;
    }

    public override float GetSpeed()
    {
        return this.GetSpeed() + 5f;
    }
} 