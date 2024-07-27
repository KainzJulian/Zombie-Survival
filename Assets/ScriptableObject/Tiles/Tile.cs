using System.Collections;
using System.Collections.Generic;
using EditorAttributes;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Tile", menuName = "Tile", order = 0)]
public class Tile : ScriptableObject
{
    [AssetPreview]
    public TileBase tile;
    public Tile[] neighbors;
    public int value;

    [Range(0f, 1f)]
    public float spawnChance;
}