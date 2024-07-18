using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RangeWeaponData : WeaponData
{
    public int projectileCount;

    [Range(1, 180)]
    public float angle;
    public int magazinSize;
    public float reloadTime;

    public int currentAmmoAmount;

    public bool isReloading = false;
}
