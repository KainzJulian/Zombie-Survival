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

    public MeleeWeapon weapon;
    public MeleeWeaponConfig weaponConfig;

    // Start is called before the first frame update
    void Start()
    {

        weapon = GetComponent<MeleeWeapon>();

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
}
