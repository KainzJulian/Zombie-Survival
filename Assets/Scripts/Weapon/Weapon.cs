using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Attackable
{
    public int damage;
    public float attackSpeed;

    public Weapon(WeaponConfig config)
    {
        damage = config.damage;
        attackSpeed = config.attackSpeed;
    }

    public virtual void attack() { }
}
