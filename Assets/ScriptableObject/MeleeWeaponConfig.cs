using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MeleeWeapon", menuName = "Weapon/Melee")]
public class MeleeWeaponConfig : WeaponConfig
{
    [Tooltip("Attack radius")]
    public int attackSize;

    public override void attack(Transform attackPoint, LayerMask layer)
    {
        Collider2D[] hit = Physics2D.OverlapCircleAll(attackPoint.position, attackSize, layer);

        foreach (var i in hit)
        {
            i.GetComponent<Health>().takeDamage(damage);
        }
    }
}
