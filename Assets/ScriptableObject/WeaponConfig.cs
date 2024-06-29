using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponConfig : ScriptableObject
{
    [Tooltip("The Point on which the attack should come from")]
    public Vector2 attackPoint;

    [Tooltip("Duration of one attack animation")]
    public float duration;

    [Tooltip("The Damage per Attack")]
    public int damage;

    [Tooltip("Time between two Attacks (lower number = faster attack)")]
    public float attackSpeed;

    public abstract void attack(Transform attackPoint, LayerMask layer, Weapon weapon);
}
