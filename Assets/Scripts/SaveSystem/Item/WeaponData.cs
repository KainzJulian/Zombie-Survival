using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeaponData : ItemData
{
    [Tooltip("Duration of one attack animation")]
    public float duration;

    [Tooltip("The Damage per Attack")]
    public int damage;

    [Tooltip("Time between two Attacks (lower number = slower attack)")]
    public float attackSpeed;

    [HideInInspector]
    public bool canAttack = true;

    [Tooltip("The Radius in which others can hear you")]
    public int noiseRadius;

    [HideInInspector]
    public float attackTimer;

    public WeaponData(WeaponConfig config) : base(config)
    {
        duration = config.duration;
        damage = config.damage;
        attackSpeed = config.attackSpeed;
        noiseRadius = config.noiseRadius;
    }
}
