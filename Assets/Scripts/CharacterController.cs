using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void moveFixed(float horizontal, float vertical)
    {
        rb.MovePosition(rb.position + new Vector2(horizontal, vertical) * (speed * Time.fixedDeltaTime));
    }

    public void move(float horizontal, float vertical)
    {
        rb.MovePosition(rb.position + speed * Time.deltaTime * new Vector2(horizontal, vertical));
    }

    public void move(Vector2 position)
    {
        Vector2 positionToFollow = (new Vector3(position.x, position.y, 0) - transform.position).normalized;
        move(positionToFollow.x, positionToFollow.y);
    }
}
