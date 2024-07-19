using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RangeWeaponData : WeaponData
{

    [Tooltip("Amount of projectiles per shot")]
    public int projectileCount;

    [Tooltip("The angle in which the bullet will be shot")]
    [Range(1, 180)]
    public float angle;

    [Tooltip("Size of the magazin")]
    public int magazinSize;

    [Tooltip("Time to reload the magazin in seconds")]
    public float reloadTime;

    [Tooltip("Current amount of ammo in magazin")]
    public int currentAmmoAmount;

    [Tooltip("Wheter the weapon is reloading or not")]
    public bool isReloading = false;
}
