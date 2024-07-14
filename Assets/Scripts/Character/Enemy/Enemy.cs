using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyAI))]
public class Enemy : MonoBehaviour
{

    [SerializeField] EnemyConfig config;
    [SerializeField] CircleCollider2D seekArea;
    [SerializeField] CharacterController2D characterController2D;
    [SerializeField] EnemyAI enemyAI;

    // Start is called before the first frame update
    void Start()
    {
        enemyAI = GetComponent<EnemyAI>();

        seekArea.radius = config.seekRadius;
        characterController2D.speed = config.movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void goToHuman()
    {
        enemyAI.goToHuman();
    }

    public void goAFK()
    {
        enemyAI.goAFK();
    }
}
