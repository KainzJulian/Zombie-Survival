using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyAI : MonoBehaviour
{

    MeleeWeapon meleeWeapon;
    [SerializeField] MeleeWeaponConfig config;
    [SerializeField] Transform attackPoint;
    [SerializeField] LayerMask layer;

    // Start is called before the first frame update
    void Start()
    {
        meleeWeapon = GetComponent<MeleeWeapon>();
        meleeWeapon.initData(config);
    }

    // Update is called once per frame
    void Update()
    {
        meleeWeapon.attack(attackPoint, layer);
    }

    private void OnDrawGizmos()
    {
        if (attackPoint != null)
            Gizmos.DrawWireSphere(attackPoint.position, config.attackSize);
    }
}
