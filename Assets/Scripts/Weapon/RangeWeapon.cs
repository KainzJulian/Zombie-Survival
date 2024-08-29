using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// TODO: alle Weapons von item erben lassen damit ich im inventar auch die daten welche nicht in scriptable obj dabei sind
// speichern kann ohne irgendwelche Probleme 
[Serializable]
public class RangeWeapon : Weapon
{
    public GameObject projectilePrefab;

    public RangeWeaponData data;
    public RangeWeaponConfig config;

    public UnityEvent<int> onAmmoChange = new UnityEvent<int>();

    private new void Start()
    {
        base.Start();
        setData();
    }

    public void setData()
    {
        config = (RangeWeaponConfig)GetComponent<Item>().config;
        data = new RangeWeaponData(config)
        {
            id = GetComponent<Item>().data.id
        };

        projectilePrefab = config.projectilePrefab;
    }

    private void Update()
    {
        if (data.attackTimer <= 0 && !data.canAttack && !data.isReloading)
        {
            data.canAttack = true;
            data.attackTimer = 1;
        }

        if (data.attackTimer > 0)
        {
            data.attackTimer -= Time.deltaTime * data.attackSpeed;
        }
    }

    public override void attack(Transform attackPoint, LayerMask layer)
    {
        if (!data.canAttack || data.isReloading)
            return;

        if (data.currentAmmoAmount <= 0)
            return;


        // is attacking
        Debug.Log("range Weapon attack");
        data.currentAmmoAmount -= 1;
        onAmmoChange?.Invoke(data.currentAmmoAmount);

        noiseSource.generateNoise(data.noiseRadius);

        for (int i = 0; i < data.projectileCount; i++)
        {
            // add spread to the bullets
            float newAngle = attackPoint.rotation.eulerAngles.z + UnityEngine.Random.Range(-data.angle, data.angle);
            GameObject projectile = Instantiate(projectilePrefab, attackPoint.position, Quaternion.Euler(0f, 0f, newAngle));

            // set damage of bullet
            projectile.GetComponent<DamageEntity>().damage = data.damage;
        }

        if (data.canAttack)
        {
            data.canAttack = false;
            data.attackTimer = 1;
        }
    }

    public void reload()
    {
        StartCoroutine(reloading());
    }

    private IEnumerator reloading()
    {
        data.isReloading = true;

        yield return new WaitForSeconds(data.reloadTime);

        data.isReloading = false;
        data.currentAmmoAmount = data.magazinSize;

        onAmmoChange?.Invoke(data.currentAmmoAmount);
    }
}
