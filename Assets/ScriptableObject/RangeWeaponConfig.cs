using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RangeWeapon", menuName = "Weapon/Range")]
public class RangeWeaponConfig : WeaponConfig
{
    [Tooltip("Amount of projectiles per shot")]
    public int projectileCount;
}
