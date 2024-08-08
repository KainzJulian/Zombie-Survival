using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EditorAttributes;
using UnityEngine;
using UnityEngine.Tilemaps;

[Serializable]
public class MultiNeighborTile : Tile
{
    [DataTable]
    public HashSet<ChanceTile> topNeighbors = new HashSet<ChanceTile>();

    [DataTable]
    public HashSet<ChanceTile> rightNeighbors = new HashSet<ChanceTile>();

    [DataTable]
    public HashSet<ChanceTile> bottomNeighbors = new HashSet<ChanceTile>();

    [DataTable]
    public HashSet<ChanceTile> leftNeighbors = new HashSet<ChanceTile>();

    public MultiNeighborTile(TileBase tile)
    {
        // id = Guid.NewGuid().GetHashCode();
        this.tile = tile;
    }

    public override List<ChanceTile> getBottomNeighbor()
    {
        return bottomNeighbors.ToList();
    }

    public override List<ChanceTile> getLeftNeighbor()
    {
        return leftNeighbors.ToList();
    }

    public override List<ChanceTile> getRightNeighbor()
    {
        return rightNeighbors.ToList();
    }

    public override List<ChanceTile> getTopNeighbor()
    {
        return topNeighbors.ToList();
    }
}