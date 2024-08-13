using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponConfig : ItemConfig
{
    [Tooltip("Duration of one attack animation")]
    public float duration;

    [Tooltip("The Damage per Attack")]
    public int damage;

    [Tooltip("Time between two Attacks (lower number = slower attack)")]
    public float attackSpeed;

    public int noiseRadius;
}
