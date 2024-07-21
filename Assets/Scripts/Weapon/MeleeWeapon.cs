using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MeleeWeapon : Weapon
{
    public MeleeWeaponData data;

    private void Update()
    {
        if (data.attackTimer <= 0 && !data.canAttack)
        {
            data.canAttack = true;
            data.attackTimer = 1;
        }

        if (data.attackTimer > 0)
            data.attackTimer -= Time.deltaTime * data.attackSpeed;
    }

    public override void attack(Transform attackPoint, LayerMask layer)
    {
        if (!data.canAttack)
            return;

        noiseSource.generateNoise(data.noiseRadius);

        Debug.Log("melee Attack");

        Collider2D[] hit = Physics2D.OverlapCircleAll(attackPoint.position, data.attackSize, layer);

        foreach (var i in hit)
        {
            i.GetComponent<Health>().takeDamage(data.damage);
        }

        if (data.canAttack)
        {
            data.canAttack = false;
            data.attackTimer = 1;
        }
    }
}
