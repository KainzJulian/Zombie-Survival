using System;
using System.Collections;
using System.Collections.Generic;
using EditorAttributes;
using UnityEditor.PackageManager;
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

    // [DataTable]
    // public List<ChanceTile> neighbors = new List<ChanceTile>();

    public override int GetHashCode()
    {
        return tile.GetHashCode() * 31 + id.GetHashCode();
    }

    public bool Equals(Tile other)
    {
        if (other == null)
            return false;

        return id == other.id && tile == other.tile;
    }

    public override bool Equals(object obj)
    {
        if (obj is Tile tileObj)
        {
            return Equals(tileObj);
        }
        return false;
    }
}
