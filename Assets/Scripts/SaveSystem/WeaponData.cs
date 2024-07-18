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

    public bool canAttack = true;

    public int noiseRadius;

    public float attackTimer;
}
