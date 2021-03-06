/*
    * Jacob Cohen
    * GearGlasses.cs
    * Assignment #4
    * Settings for the glasses decorator
*/

using UnityEngine;
using System.Collections;

public class GearGlasses : GearDecorator
{
    Character character;

    //constructor
    public GearGlasses(Character character)
    {
        this.character = character;
    }

    public override int GetDamage()
    {
        return character.GetDamage() + 1;
    }

    public override float GetSpeed()
    {
        return character.GetSpeed() - 1f;
    }

    public override int GetHealth()
    {
        return character.GetHealth() - 1;
    }
}