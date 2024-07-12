using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeaponData
{
    public RangeWeapon rangeWeapon;
    public MeleeWeapon meleeWeapon;

    public WeaponData(RangeWeapon range, MeleeWeapon melee)
    {
        rangeWeapon = range;
        meleeWeapon = melee;
    }
}
