using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponConfig : ScriptableObject
{

    [Tooltip("Type of weapon")]
    public WeaponType weaponType;

    [Tooltip("Duration of one attack animation")]
    public float duration;

    [Tooltip("The Damage per Attack")]
    public int damage;

    [Tooltip("Time between two Attacks (lower number = faster attack)")]
    public float attackSpeed;
}

public enum WeaponType
{
    Range,
    Melee,
    Throwable
}
