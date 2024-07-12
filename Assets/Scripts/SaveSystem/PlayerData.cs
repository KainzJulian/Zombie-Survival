

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

        Debug.LogWarning(playerManager);
        Debug.LogWarning(playerManager.gameObject);
        Debug.LogWarning(playerManager.gameObject.transform);
        Debug.LogWarning(playerManager.gameObject.transform.position);

        health = playerManager.gameObject.GetComponent<Health>().health;

        Vector3 position = playerManager.gameObject.transform.position;

        x = position.x;
        y = position.y;
    }
}
