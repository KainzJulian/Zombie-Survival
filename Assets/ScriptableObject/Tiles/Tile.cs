using System;
using System.Collections;
using System.Collections.Generic;
using EditorAttributes;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Tile", menuName = "Tile", order = 0)]
public class Tile : ScriptableObject, IEquatable<Tile>
{
    [Required]
    public int id;

    [AssetPreview]
    public TileBase tile;


    [DataTable]
    public List<ChanceTile> topNeighbors = new List<ChanceTile>();

    [DataTable]
    public List<ChanceTile> rightNeighbors = new List<ChanceTile>();

    [DataTable]
    public List<ChanceTile> bottomNeighbors = new List<ChanceTile>();

    [DataTable]
    public List<ChanceTile> leftNeighbors = new List<ChanceTile>();


    public override int GetHashCode()
    {
        return tile.GetHashCode() * 31 + id.GetHashCode();
    }


    public bool Equals(Tile obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        return id == obj.id;
    }
}

[Serializable]
public class ChanceTile : IEquatable<ChanceTile>
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

    public bool Equals(ChanceTile obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        return spawnChance == obj.spawnChance && tile.Equals(obj);
    }
}