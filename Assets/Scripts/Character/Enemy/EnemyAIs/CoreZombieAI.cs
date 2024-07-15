using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CoreZombieAI : MonoBehaviour, ZombieAI
{
    //TODO: enemy AI
    [SerializeField] protected Transform attackPoint;
    [SerializeField] protected LayerMask layer;
    public CharacterController2D controller2D;
    [SerializeField] protected AttackPointController attackPointController;

    [SerializeField] protected Enemy enemy;

    protected Vector2 positionToMove;

    protected bool isAFK = true;

    private void Awake()
    {
        positionToMove = transform.position;
    }

    protected bool checkAFK()
    {
        return !isAFK;
    }

    protected bool checkDistance()
    {
        return Vector2.Distance((Vector2)transform.position, positionToMove) <= 0.1f;
    }

    protected void setNewPositionToMove()
    {
        positionToMove = (Vector2)transform.position + Random.insideUnitCircle * enemy.config.AFKRadius;
    }

    protected void waitSetPositionToMove(float timeSeconds)
    {
        Invoke("setNewPositionToMove", timeSeconds);
    }

    protected void waitExecute(float timeSeconds, System.Action action)
    {
        StartCoroutine(waitExecuteAction(timeSeconds, action));
        Debug.LogWarning("test");
    }

    IEnumerator waitExecuteAction(float timeSeconds, System.Action callback)
    {
        yield return new WaitForSeconds(timeSeconds);

        callback?.Invoke();
    }

    protected void rotateAttackPoint(Vector2 position)
    {
        attackPointController.rotateAttackPoint(position);
    }

    public virtual void goToHuman(Transform position)
    {
        isAFK = false;

        if (Vector2.Distance((Vector2)attackPoint.position, position.position) <= enemy.weapon.attackSize)
        {
            enemy.weapon.attack(attackPoint, layer);
        }

        controller2D.move(position.position);

        attackPointController.rotateAttackPoint(position.position);
    }

    public virtual void goAFK()
    {
        setNewPositionToMove();
        performAFK();
        isAFK = true;
    }

    protected void performAFK()
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
