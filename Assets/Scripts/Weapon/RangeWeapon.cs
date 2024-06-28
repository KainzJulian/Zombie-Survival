using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeapon : Weapon
{
    public float angle;

    public int magazinSize;
    public int currentAmmoAmount;

    public RangeWeapon(RangeWeaponConfig config) : base(config)
    {
        angle = config.angle;
        magazinSize = config.magazinSize;
    }
}
