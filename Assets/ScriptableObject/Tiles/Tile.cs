using System;
using System.Collections;
using System.Collections.Generic;
using EditorAttributes;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Tile", menuName = "Tile", order = 0)]
public class Tile : ScriptableObject
{
    public int id;

    [AssetPreview]
    public TileBase tile;


    [DataTable]
    public ChanceTile[] topNeighbors;

    [DataTable]
    public ChanceTile[] rightNeighbors;

    [DataTable]
    public ChanceTile[] bottomNeighbors;

    [DataTable]
    public ChanceTile[] leftNeighbors;


    public override int GetHashCode()
    {
        return tile.GetHashCode() * 31 + id.GetHashCode();
    }


    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        Tile other = (Tile)obj;

        return id == other.id;
    }
}

[Serializable]
public class ChanceTile
{
    [Range(0f, 1f)]
    public float spawnChance;

    public Tile tile;

    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 31 + spawnChance.GetHashCode();
        hash = hash * 31 + (tile != null ? tile.GetHashCode() : 0);
        return hash;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        ChanceTile other = (ChanceTile)obj;
        return spawnChance == other.spawnChance && tile.Equals(other.tile);
    }
}