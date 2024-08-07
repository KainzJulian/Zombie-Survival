using System;
using UnityEngine;
using UnityEngine.Tilemaps;

[Serializable]
public class ChanceTile : IEquatable<ChanceTile>
{
   [Range(0f, 1f)]
   public int weight;

   public TileBase tile;

   public ChanceTile(Tile tile, int weight = 1)
   {
      this.tile = tile.tile;
      this.weight = weight;
   }

   public ChanceTile(TileBase tile, int weight = 1)
   {
      this.tile = tile;
      this.weight = weight;
   }

   public override int GetHashCode()
   {
      int hash = 17;
      hash = hash * 31 + (tile != null ? tile.GetHashCode() : 0);
      return hash;
   }

   public bool Equals(ChanceTile other)
   {
      if (other == null)
         return false;

      return tile != null ? tile == other.tile : other.tile == null;
   }

   public override bool Equals(object obj)
   {
      if (obj is ChanceTile chanceTileObj)
      {
         return Equals(chanceTileObj);
      }
      return false;
   }
}