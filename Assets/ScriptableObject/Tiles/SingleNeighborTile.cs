using System.Collections;
using System.Collections.Generic;
using EditorAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "SingleNeighbor", menuName = "Tile/SingleNeighbor", order = 0)]
public class SingleNeighborTile : Tile
{
   [DataTable]
   public List<ChanceTile> neighbors;

   public override List<ChanceTile> getBottomNeighbor()
   {
      return getNeighbor();
   }

   public override List<ChanceTile> getLeftNeighbor()
   {
      return getNeighbor();
   }

   public override List<ChanceTile> getRightNeighbor()
   {
      return getNeighbor();
   }

   public override List<ChanceTile> getTopNeighbor()
   {
      return getNeighbor();
   }

   private List<ChanceTile> getNeighbor()
   {
      return neighbors;
   }
}
