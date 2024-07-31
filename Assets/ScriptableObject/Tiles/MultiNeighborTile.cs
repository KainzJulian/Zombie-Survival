using System.Collections;
using System.Collections.Generic;
using EditorAttributes;
using UnityEngine;

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


    public override List<ChanceTile> getNeighbor(Vector3Int direction = new Vector3Int())
    {
        if (direction == Vector3Int.down)
            return topNeighbors;
        if (direction == Vector3Int.up)
            return bottomNeighbors;
        if (direction == Vector3Int.right)
            return leftNeighbors;
        if (direction == Vector3Int.left)
            return rightNeighbors;
        return null;
    }
}
