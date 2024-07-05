using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPointController : MonoBehaviour
{
    private void FixedUpdate()
    {
        rotateAttackPoint();
    }

    private void rotateAttackPoint()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // attackPoint.Rotate(playerPosition.position, 90f);

        Vector2 direction = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
