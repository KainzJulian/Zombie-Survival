using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyAI))]
public class Enemy : MonoBehaviour
{

    public EnemyConfig config;
    [SerializeField] CircleCollider2D seekArea;
    [SerializeField] CharacterController2D characterController2D;
    [SerializeField] EnemyAI enemyAI;
    [SerializeField] Health health;

    // Start is called before the first frame update
    void Start()
    {
        enemyAI = GetComponent<EnemyAI>();

        health.health = config.health;

        seekArea.radius = config.seekRadius;
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
