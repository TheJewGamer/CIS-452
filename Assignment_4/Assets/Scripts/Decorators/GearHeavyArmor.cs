/*
    * Jacob Cohen
    * GearHeavyArmor.cs
    * Assignment #4
    * Settings for the heavy armor decorator
*/

using UnityEngine;
using System.Collections;

public class GearHeavyArmor : GearDecorator
{
    Character character;

    //constructor
    public GearHeavyArmor(Character character)
    {
        this.character = character;
    }

    public override int GetDamage()
    {
        return character.GetDamage() + 1;
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