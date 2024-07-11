

using System;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public float x;
    public float y;

    public int health;

    public PlayerData(PlayerManager playerManager)
    {
        health = playerManager.gameObject.GetComponent<Health>().health;

        Vector3 position = playerManager.gameObject.transform.position;

        x = position.x;
        y = position.y;
    }
}
