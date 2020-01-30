/*
    * Jacob Cohen
    * ChangeWeaponBehavior.cs
    * Assignment #2
    * Controls changing the player sprite when the weapon is switched
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeaponPistol : ChangeWeaponBehavior
{
    public override void ChangeWeapon()
    {
        GetComponent<SpriteRenderer>().sprite = GameObject.Find("pistolSprite").GetComponent<SpriteRenderer>().sprite;
    }
}

public class ChangeWeaponMachineGun : ChangeWeaponBehavior
{ 
    public override void ChangeWeapon()
    {
        GetComponent<SpriteRenderer>().sprite = GameObject.Find("machineGunSprite").GetComponent<SpriteRenderer>().sprite;
    }
}
