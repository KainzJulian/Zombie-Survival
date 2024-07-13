using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeaponData
{
    public WeaponType weaponType;
    public float duration;
    public int damage;
    public float attackSpeed;

    public WeaponData(Weapon weapon)
    {
        weaponType = weapon.weaponType;
        duration = weapon.duration;
        damage = weapon.damage;
        attackSpeed = weapon.attackSpeed;
    }
}
