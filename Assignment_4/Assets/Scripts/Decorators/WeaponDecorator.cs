using UnityEngine;
using System.Collections;

public abstract class WeaponDecorator : Character
{
    public override abstract float GetRange();
    public override abstract int GetDamage();
} 