using System.Collections;
using System.Collections.Generic;
using EditorAttributes;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "MultiNeighbor", menuName = "Tile/MultiNeighbor", order = 0)]
public class MultiNeighborTile : Tile
{
    [DataTable]
    public List<ChanceTile> topNeighbors;

    [DataTable]
    public List<ChanceTile> rightNeighbors;

    [DataTable]
    public List<ChanceTile> bottomNeighbors;

    [DataTable]
    public List<ChanceTile> leftNeighbors;

    public MultiNeighborTile(int id, TileBase tile)
    {
        this.id = id;
        this.tile = tile;
    }

    public override List<ChanceTile> getBottomNeighbor()
    {
        return bottomNeighbors;
    }

    public override List<ChanceTile> getLeftNeighbor()
    {
        return leftNeighbors;
    }

    public override List<ChanceTile> getRightNeighbor()
    {
        return rightNeighbors;
    }

    public override List<ChanceTile> getTopNeighbor()
    {
        return topNeighbors;
    }
}
