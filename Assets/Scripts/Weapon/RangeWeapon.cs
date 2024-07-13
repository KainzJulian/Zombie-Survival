using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class RangeWeapon : Weapon
{
    public int projectileCount;
    public GameObject projectilePrefab;
    public float angle;
    public int magazinSize;
    public float reloadTime;

    public int currentAmmoAmount;

    private bool isReloading = false;

    public UnityEvent<int> onCurrentAmmoChange = new UnityEvent<int>();

    private void Update()
    {
        if (helpAttackTime <= 0 && !canAttack && !isReloading)
        {
            canAttack = true;
            helpAttackTime = 1;
        }

        if (helpAttackTime > 0)
        {
            helpAttackTime -= Time.deltaTime * attackSpeed;
        }
    }

    public override void attack(Transform attackPoint, LayerMask layer)
    {
        if (!canAttack || isReloading)
            return;

        if (currentAmmoAmount <= 0)
            return;

        Debug.Log("range Weapon attack");
        currentAmmoAmount -= 1;
        onCurrentAmmoChange?.Invoke(currentAmmoAmount);

        for (int i = 0; i < projectileCount; i++)
        {
            // add spread to the bullets
            float newAngle = attackPoint.rotation.eulerAngles.z + UnityEngine.Random.Range(-angle, angle);
            GameObject projectile = Instantiate(projectilePrefab, attackPoint.position, Quaternion.Euler(0f, 0f, newAngle));

            // set damage of bullet
            projectile.GetComponent<DamageEntity>().damage = damage;
        }

        base.attack(attackPoint, layer);
    }

    public void reload()
    {
        StartCoroutine(reloading());
    }

    private IEnumerator reloading()
    {
        isReloading = true;

        yield return new WaitForSeconds(reloadTime);

        isReloading = false;
        currentAmmoAmount = magazinSize;
        onCurrentAmmoChange?.Invoke(currentAmmoAmount);
    }

    public void initData(RangeWeaponConfig config)
    {
        base.initData(config);

        projectileCount = config.projectileCount;
        projectilePrefab = config.projectilePrefab;
        angle = config.angle;
        magazinSize = config.magazinSize;
        reloadTime = config.reloadTime;
    }

    public void setData(RangeWeaponData config)
    {
        projectileCount = config.projectileCount;
        angle = config.angle;
        magazinSize = config.magazinSize;
        reloadTime = config.reloadTime;
        currentAmmoAmount = config.currentAmmoAmount;

        base.setData(config);
    }
}
