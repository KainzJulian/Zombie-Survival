using System;
using UnityEngine;

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

   public bool Equals(ChanceTile other)
   {
      if (other == null)
         return false;

      return spawnChance == other.spawnChance &&
             (tile != null ? tile.Equals(other.tile) : other.tile == null);
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
