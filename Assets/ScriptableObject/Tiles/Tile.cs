using System;
using System.Collections;
using System.Collections.Generic;
using EditorAttributes;
using NaughtyAttributes;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class Tile : ScriptableObject, IEquatable<Tile>, ITile
{
    [EditorAttributes.Required]
    public int id;

    [AssetPreview]
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

    public abstract List<ChanceTile> getNeighbor(Vector3Int direction = new Vector3Int());
}
