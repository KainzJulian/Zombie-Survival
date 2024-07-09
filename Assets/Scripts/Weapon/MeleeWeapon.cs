using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    public int attackSize;
    public MeleeWeaponConfig meleeWeaponConfig;

    private void Update()
    {
        if (helpAttackTime <= 0 && !canAttack)
        {
            canAttack = true;
            helpAttackTime = 1;
        }

        if (helpAttackTime > 0)
            helpAttackTime -= Time.deltaTime * attackSpeed;
    }

    public void initData(MeleeWeaponConfig config)
    {
        base.initData(config);

        meleeWeaponConfig = config;

        attackSize = config.attackSize;
    }

    public override void attack(Transform attackPoint, LayerMask layer)
    {

        if (!canAttack)
            return;

        Debug.Log("melee Attack");

        Collider2D[] hit = Physics2D.OverlapCircleAll(attackPoint.position, attackSize, layer);

        foreach (var i in hit)
        {
            i.GetComponent<Health>().takeDamage(damage);
        }

        base.attack(attackPoint, layer);
    }
}
