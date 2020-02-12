using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassRanger : Character
{
    public ClassRanger()
    {
        this.description = "Ranger";
    }

    public override int GetHealth()
    {
        return 5;
    }

    public override float GetSpeed()
    {
        return 3f;
    }
}