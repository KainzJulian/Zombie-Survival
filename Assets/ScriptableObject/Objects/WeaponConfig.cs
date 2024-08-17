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

    // TODO: add for all child classes of this one and itemconfig an equals and hashcode method
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        WeaponConfig other = (WeaponConfig)obj;

        return base.Equals(other)
            && duration == other.duration
            && damage == other.damage
            && attackSpeed == other.attackSpeed
            && noiseRadius == other.noiseRadius;
    }

    public override int GetHashCode()
    {
        return (name, sprite, description, type).GetHashCode() + base.GetHashCode();
    }
}
