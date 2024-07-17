using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Weapon : MonoBehaviour
{
    //TODO Add Throwable (Grenades, Knifes, bottle, items which are throwable)
    public WeaponType weaponType;
    public float duration;
    public int damage;
    public float attackSpeed;

    public bool canAttack = true;

    protected float helpAttackTime;

    public int noiseRadius;

    public void initData(WeaponConfig config)
    {
        weaponType = config.weaponType;
        duration = config.duration;
        damage = config.damage;
        attackSpeed = config.attackSpeed;
        noiseRadius = config.noiseRadius;
    }

    public void setData(WeaponData config)
    {
        weaponType = config.weaponType;
        duration = config.duration;
        damage = config.damage;
        attackSpeed = config.attackSpeed;
    }

    public virtual void attack(Transform attackPoint, LayerMask layer)
    {
        if (canAttack)
        {
            helpAttackTime = 1;
            canAttack = false;
        }
    }
}
