using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMover : MonoBehaviour
{
    public float speed { private get; set; } = 900f;

    [SerializeField, Range(0.1f, 10)] float minSpeedModifier = 1;
    [SerializeField, Range(0.1f, 10)] float maxSpeedModifier = 1;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed * Random.Range(minSpeedModifier, maxSpeedModifier);
    }
}
