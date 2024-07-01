using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RangeWeapon : Weapon
{
    public int projectileCount;
    public GameObject projectilePrefab;
    public float angle;
    public int magazinSize;

    // default should be removed in later iterations
    public int currentAmmoAmount = 20;

    [SerializeField] TextMeshProUGUI maxAmmoText;
    [SerializeField] TextMeshProUGUI currentAmmoText;
    [SerializeField] GameObject rangeUI;

    public override void attack(Transform attackPoint, LayerMask layer)
    {
        if (currentAmmoAmount <= 0)
            return;

        Debug.Log("range Weapon attack");
        currentAmmoAmount -= 1;

        for (int i = 0; i < projectileCount; i++)
        {
            // add spread to the bullets
            float newAngle = attackPoint.rotation.eulerAngles.z + Random.Range(-angle, angle);
            GameObject projectile = Instantiate(projectilePrefab, attackPoint.position, Quaternion.Euler(0f, 0f, newAngle));

            // set damage of bullet
            projectile.GetComponent<DamageEntity>().damage = damage;
        }
    }

    public void initData(RangeWeaponConfig config)
    {
        base.initData(config);

        projectileCount = config.projectileCount;
        projectilePrefab = config.projectilePrefab;
        angle = config.angle;
        magazinSize = config.magazinSize;
    }

    public void switchUI(bool state)
    {
        rangeUI.SetActive(state);
    }

    public void setMaxAmmoText()
    {
        maxAmmoText.SetText(magazinSize.ToString());
    }

    public void setCurrentAmmoText()
    {
        currentAmmoText.SetText(currentAmmoAmount.ToString());
    }
}
