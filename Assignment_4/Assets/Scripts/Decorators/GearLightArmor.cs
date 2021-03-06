/*
    * Jacob Cohen
    * GearLightArmor.cs
    * Assignment #4
    * Settings for the light armor decorator
*/

using UnityEngine;
using System.Collections;

public class GearLightArmor : GearDecorator
{
    Character character;

    //constructor
    public GearLightArmor(Character character)
    {
        this.character = character;
    }

    public override int GetDamage()
    {
        return character.GetDamage() - 1;
    }

    public override float GetSpeed()
    {
        return character.GetSpeed() + 2f;
    }

    public override int GetHealth()
    {
        return character.GetHealth() - 1;
    }
}