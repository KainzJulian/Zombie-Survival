using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MeleeAttackController : MonoBehaviour
{
    public int size = 10;
    [SerializeField] Transform attackPoint;
    [SerializeField] Transform playerPosition;
    [SerializeField] LayerMask layer;

    [SerializeField] MeleeWeaponConfig weaponConfig;

    public void attack(Damagable damagable = null, int damageAmount = 0)
    {
        Collider2D[] hit = Physics2D.OverlapCircleAll(attackPoint.position, size, layer);

        foreach (var i in hit)
        {
            i.GetComponent<Damagable>().takeDamage(damageAmount);
        }
    }

    private void OnDrawGizmos()
    {
        if (attackPoint != null)
            Gizmos.DrawWireSphere(attackPoint.position, size);
    }
}
