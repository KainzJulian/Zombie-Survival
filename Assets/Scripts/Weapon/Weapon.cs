using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    public int damage;
    public float attackSpeed;

    public Weapon(WeaponConfig config)
    {
        damage = config.damage;
        attackSpeed = config.attackSpeed;
    }
}
