using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Config/Enemy")]
public class EnemyConfig : NPCConfig
{
    [Tooltip("Radius in which the player is recognised")]
    public int seekRadius;

    [Tooltip("Radius in which a random position will be chosen and then gone to")]
    public int AFKRadius;

    public int health;
}
