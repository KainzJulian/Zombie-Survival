using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RangeWeaponData : WeaponData
{
    public int projectileCount;
    public float angle;
    public int magazinSize;
    public float reloadTime;

    public int currentAmmoAmount;

    public RangeWeaponData(RangeWeapon weapon) : base(weapon)
    {
        projectileCount = weapon.projectileCount;
        angle = weapon.angle;
        magazinSize = weapon.magazinSize;
        reloadTime = weapon.reloadTime;
        currentAmmoAmount = weapon.currentAmmoAmount;
    }
}
