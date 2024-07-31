using System.Collections;
using System.Collections.Generic;
using EditorAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "SingleNeighbor", menuName = "Tile/SingleNeighbor", order = 0)]
public class SingleNeighborTile : Tile
{
   [DataTable]
   public List<ChanceTile> neighbors;

   public override List<ChanceTile> getNeighbor(Vector3Int direction = new Vector3Int())
   {
      return neighbors;
   }
}
