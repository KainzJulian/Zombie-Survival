using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyAI : MonoBehaviour, EnemyAI
{
    //TODO: enemy AI
    MeleeWeapon meleeWeapon;
    [SerializeField] MeleeWeaponConfig config;
    [SerializeField] Transform attackPoint;
    [SerializeField] LayerMask layer;

    void Start()
    {
        meleeWeapon = GetComponent<MeleeWeapon>();
        meleeWeapon.initData(config);
    }

    void Update()
    {
        meleeWeapon.attack(attackPoint, layer);
    }

    public void goToHuman()
    {
        Debug.Log("go to human");
    }

    public void goAFK()
    {
        Debug.Log("go to AFK");
    }

    private void OnDrawGizmos()
    {
        if (attackPoint != null)
            Gizmos.DrawWireSphere(attackPoint.position, config.attackSize);
    }
}
