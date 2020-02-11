using UnityEngine;
using System.Collections;

public class WeaponKnife : WeaponDecorator
{
    Character character;

    //constructor
    public WeaponKnife(Character character)
    {
        this.character = character;
    }

    public override int GetDamage()
    {
        return character.GetDamage() + 3;
    }

    public override float GetRange()
    {
        return character.GetRange() + 100;
    }

    public override float GetSpeed()
    {
        return character.GetSpeed() + 5f;
    }

    public override int GetHealth()
    {
        return character.GetHealth() - 1;
    }

}