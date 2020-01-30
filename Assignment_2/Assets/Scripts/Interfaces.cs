/*
    * Jacob Cohen
    * Interfaces.cs
    * Assignment #2
    * implements the interfaces used in the project
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRangedWeapon
{
    void Shoot();

    void Reload();

    void HudUpdate();
}

public abstract class ChangeWeaponBehavior : MonoBehaviour
{
    IRangedWeapon rangedWeaponBehavior;

    public abstract void ChangeWeapon();
}
