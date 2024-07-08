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

    private float helpAttackTime;

    private void Update()
    {
        if (helpAttackTime <= 0 && !canAttack)
        {
            canAttack = true;
            helpAttackTime = 1;
        }

        if (helpAttackTime > 0)
        {
            helpAttackTime -= Time.deltaTime * attackSpeed;
        }
    }

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
