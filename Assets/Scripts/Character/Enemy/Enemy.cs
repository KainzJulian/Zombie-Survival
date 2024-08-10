using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ZombieAI))]
public class Enemy : MonoBehaviour
{

    public EnemyConfig config;
    [SerializeField] CharacterController2D characterController2D;
    [SerializeField] ZombieAI enemyAI;
    [SerializeField] Health health;

    public WeaponController weaponController;

    void Start()
    {
        enemyAI = GetComponent<ZombieAI>();

        health.health = config.health;

        characterController2D.speed = config.movementSpeed;
    }

    public void goToHuman(Transform position)
    {
        enemyAI.goToHuman(position);
    }

    public void goAFK()
    {
        enemyAI.goAFK();
    }

    // TODO: Die hier entfernen und WeaponController so machen das 
    //er auch für Enemy funktioniert weil dort gibts sowas schon
    public MeleeWeapon getWeaponAsMelee()
    {
        return weaponController.getWeaponAsMelee();
    }

    public RangeWeapon getWeaponAsRange()
    {
        return weaponController.getWeaponAsRange();
    }
}
