using UnityEngine;
using System.Collections;

public class GearScope : GearDecorator
{
    Character character;

    //constructor
    public GearScope(Character character)
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