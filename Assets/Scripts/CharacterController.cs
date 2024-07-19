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

    private float helpTime = 1;

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
        baseMove(horizontal, vertical, type, Time.fixedDeltaTime);
    }

    private void baseMove(float horizontal, float vertical, SpeedType type, float deltaTime)
    {
        helpTime -= deltaTime * getStepSpeed(type);

        if (horizontal == 0 && vertical == 0)
            return;

        float speedTypeMultiplier = (int)type / 100;
        Vector2 posVector = new Vector2(horizontal, vertical);

        rb.MovePosition(rb.position + posVector * speed * deltaTime * speedTypeMultiplier);

        if (helpTime <= 0)
        {
            noiseSource.generateNoise(getNoiseRadius(type));
            helpTime = 1;
        }
    }

    private float getStepSpeed(SpeedType type)
    {
        switch (type)
        {
            case SpeedType.SNEAK:
                return 0.5f;
            case SpeedType.WALK:
                return 1f;
            case SpeedType.SPRINT:
                return 3f;
        }

        return 0;
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
        baseMove(horizontal, vertical, type, Time.deltaTime);
    }

    public void moveFixed(Vector2 position, SpeedType type = SpeedType.WALK)
    {
        Vector2 newPosition = (new Vector3(position.x, position.y, 0) - transform.position).normalized;
        baseMove(newPosition.x, newPosition.y, type, Time.fixedDeltaTime);
    }

    public void move(Vector2 position, SpeedType type = SpeedType.WALK)
    {
        Vector2 newPosition = (new Vector3(position.x, position.y, 0) - transform.position).normalized;
        baseMove(newPosition.x, newPosition.y, type, Time.deltaTime);
    }
}
