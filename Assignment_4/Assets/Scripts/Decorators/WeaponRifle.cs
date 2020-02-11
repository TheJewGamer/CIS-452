using UnityEngine;
using System.Collections;

public class WeaponRifle : WeaponDecorator
{
    Character character;

    //constructor
    public WeaponRifle(Character character)
    {
        this.character = character;
    }

    public override int GetDamage()
    {
        return character.GetDamage() + 100;
    }

    public override float GetRange()
    {
        return character.GetRange() + 5;
    }

    public override float GetSpeed()
    {
        return character.GetSpeed() - 2f;
    }

    public override int GetHealth()
    {
        return character.GetHealth() + 1;
    }
}