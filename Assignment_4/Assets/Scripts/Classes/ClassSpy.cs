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
        return 3;
    }

    public override float GetSpeed()
    {
        return 5f;
    }
} 