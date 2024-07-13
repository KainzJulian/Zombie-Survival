using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MeleeWeaponData : WeaponData
{
    public int attackSize;

    public MeleeWeaponData(MeleeWeapon weapon) : base(weapon)
    {
        attackSize = weapon.attackSize;
    }
}
