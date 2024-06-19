using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RangeWeapon", menuName = "Weapon/Range")]
public class RangeWeaponConfig : WeaponConfig
{
    [Tooltip("After which time the bullet will be destroyed in Seconds")]
    public float lifeTime;

    [Tooltip("Amount of projectiles per shot")]
    public int projectileCount;

    [Tooltip("Projectile which will be shot")]
    public GameObject projectilePrefab;

    public override void attack(Transform attackPoint, LayerMask layer)
    {
        GameObject projectile = Instantiate(projectilePrefab, attackPoint.position, attackPoint.rotation);

        projectile.GetComponent<DamageEntity>().damage = damage;
        projectile.GetComponent<LifeSpanController>().setLifeTime(lifeTime);
    }
}
