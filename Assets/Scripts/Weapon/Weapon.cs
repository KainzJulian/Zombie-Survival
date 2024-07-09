using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponType weaponType;
    public float duration;
    public int damage;
    public float attackSpeed;

    public bool canAttack = true;

    protected float helpAttackTime;

    public void initData(WeaponConfig config)
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
