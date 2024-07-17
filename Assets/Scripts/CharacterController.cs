using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(NoiseSource))]
public class CharacterController2D : MonoBehaviour
{
    Rigidbody2D rb;
    NoiseSource noiseSource;

    public float speed;

    public enum SpeedType
    {
        SNEAK = 50,
        WALK = 100,
        SPRINT = 180
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        noiseSource = GetComponent<NoiseSource>();
    }

    public void moveFixed(float horizontal, float vertical, SpeedType type)
    {
        float speedTypeMultiplier = (int)type / 100;
        rb.MovePosition(rb.position + new Vector2(horizontal, vertical) * (speed * Time.fixedDeltaTime) * speedTypeMultiplier);
        noiseSource.generateNoise(getNoiseRadius(type));
    }

    private int getNoiseRadius(SpeedType type)
    {
        switch (type)
        {
            case SpeedType.SNEAK:
                return 0;
            case SpeedType.WALK:
                return 60;
            case SpeedType.SPRINT:
                return 120;
        }

        return 0;
    }

    public void move(float horizontal, float vertical, SpeedType type)
    {
        float speedTypeMultiplier = (int)type / 100;
        rb.MovePosition(rb.position + speed * Time.deltaTime * new Vector2(horizontal, vertical) * speedTypeMultiplier);
    }

    public void move(Vector2 position, SpeedType type = SpeedType.WALK)
    {
        Vector2 newPosition = (new Vector3(position.x, position.y, 0) - transform.position).normalized;
        move(newPosition.x, newPosition.y, type);
    }
}
