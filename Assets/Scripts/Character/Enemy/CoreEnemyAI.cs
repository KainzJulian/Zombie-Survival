using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreEnemyAI : MonoBehaviour, EnemyAI
{
    //TODO: enemy AI
    [SerializeField] Transform attackPoint;
    [SerializeField] LayerMask layer;
    [SerializeField] CharacterController2D controller2D;
    [SerializeField] AttackPointController attackPointController;

    [SerializeField] Enemy enemy;

    Vector2 positionToMove;

    bool isAFK = true;

    void Start()
    {
        positionToMove = transform.position;
    }

    void Update()
    {
        if (!isAFK)
            return;

        if (Vector2.Distance((Vector2)transform.position, positionToMove) <= 0.1f)
        {
            setNewPositionToMove();
            attackPointController.rotateAttackPoint(positionToMove);
        }

        performAFK();
    }

    private void setNewPositionToMove()
    {
        positionToMove = (Vector2)transform.position + Random.insideUnitCircle * enemy.config.AFKRadius;
        Debug.Log(positionToMove.ToString());
    }

    public void goToHuman(Transform position)
    {
        isAFK = false;

        if (Vector2.Distance((Vector2)attackPoint.position, position.position) <= enemy.weapon.attackSize)
        {
            enemy.weapon.attack(attackPoint, layer);
        }

        controller2D.move(position.position);

        attackPointController.rotateAttackPoint(position.position);
    }

    public void goAFK()
    {
        setNewPositionToMove();
        performAFK();
        isAFK = true;
    }

    private void performAFK()
    {
        controller2D.move(positionToMove);
    }

    private void OnDrawGizmos()
    {
        if (attackPoint != null)
            Gizmos.DrawWireSphere(attackPoint.position, enemy.weaponConfig.attackSize);
        if (enemy != null)
        {
            Gizmos.DrawWireSphere(transform.position, enemy.config.AFKRadius);
            Gizmos.DrawWireSphere(transform.position, enemy.config.seekRadius);
        }

        Gizmos.color = new Color(1, 0, 0, 1);
        Gizmos.DrawSphere(positionToMove, 3);
    }
}
