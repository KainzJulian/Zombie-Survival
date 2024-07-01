using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RangeWeapon", menuName = "Weapon/Range")]
public class RangeWeaponConfig : WeaponConfig
{
    [Tooltip("Amount of projectiles per shot")]
    public int projectileCount;

    [Tooltip("Projectile which will be shot")]
    public GameObject projectilePrefab;

    [Tooltip("The angle in which the bullet will be shot")]
    [Range(0, 360)]
    public float angle;

    public int magazinSize;
}
