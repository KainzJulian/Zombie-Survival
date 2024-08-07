using System;
using System.Collections.Generic;
using EditorAttributes;
using NaughtyAttributes;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class Tile : IEquatable<Tile>, ITile
{
    [EditorAttributes.ReadOnly]
    public int id = 0;

    [ShowAssetPreview]
    public TileBase tile;

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

    public abstract List<ChanceTile> getTopNeighbor();

    public abstract List<ChanceTile> getRightNeighbor();

    public abstract List<ChanceTile> getBottomNeighbor();

    public abstract List<ChanceTile> getLeftNeighbor();
}