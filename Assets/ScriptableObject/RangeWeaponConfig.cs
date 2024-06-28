using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RangeWeapon", menuName = "Weapon/Range")]
public class RangeWeaponConfig : WeaponConfig
{
    [Tooltip("Amount of projectiles per shot")]
    public int projectileCount;

    [Tooltip("Projectile which will be shot")]
    public GameObject projectilePrefab;

    [Tooltip("The angle in which the bullet will be shot")]
    [Range(0, 360)]
    public float angle;

    public int magazinSize;

    public override void attack(Transform attackPoint, LayerMask layer)
    {
        for (int i = 0; i < projectileCount; i++)
        {
            // add spread to the bullets
            float newAngle = attackPoint.rotation.eulerAngles.z + Random.Range(-angle, angle);
            GameObject projectile = Instantiate(projectilePrefab, attackPoint.position, Quaternion.Euler(0f, 0f, newAngle));

            // set damage of bullet
            projectile.GetComponent<DamageEntity>().damage = damage;
        }
    }
}
