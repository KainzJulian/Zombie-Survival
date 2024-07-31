using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

[Serializable]
public class PossibleTilesMap
{
   public int[,] entrophieLevelMap;

   public HashSet<ChanceTile> possibleTiles = new HashSet<ChanceTile>();
   private List<ChanceTile> possibleTiles_copy = new List<ChanceTile>();

   public List<Tile> tiles;

   public int width;
   public int height;

   public PossibleTilesMap(int width, int height, List<Tile> tiles)
   {
      this.width = width;
      this.height = height;

      foreach (Tile tile in tiles)
      {
         possibleTiles.AddRange(tile.getNeighbor(Vector3Int.up));
         possibleTiles.AddRange(tile.getNeighbor(Vector3Int.right));
         possibleTiles.AddRange(tile.getNeighbor(Vector3Int.down));
         possibleTiles.AddRange(tile.getNeighbor(Vector3Int.left));
      }

      if (possibleTiles.Count != tiles.Count())
      {

         Debug.LogWarning(possibleTiles.Count + "  " + tiles.Count());
         foreach (ChanceTile item in possibleTiles)
         {
            Debug.Log(item.tile.tile);
         }
         throw new Exception("There are too many ChanceTiles in the Tiles provided");
      }

      this.tiles = tiles;

      possibleTiles_copy = possibleTiles.ToList();

      entrophieLevelMap = new int[height, width];

      for (int y = 0; y < height; y++)
      {
         for (int x = 0; x < width; x++)
         {
            entrophieLevelMap[y, x] = possibleTiles.Count;
         }
      }
   }

   public Vector3Int getRandomPosition()
   {
      return new Vector3Int(
          UnityEngine.Random.Range(0, width),
          UnityEngine.Random.Range(0, height)
      );
   }

   public void updateEntrophieMap(Vector3Int position, int newValue)
   {
      if (isValidPosition(position))
         return;

      if (entrophieLevelMap[position.y, position.x] == -1)
         return;

      entrophieLevelMap[position.y, position.x] = newValue;
   }

   private bool isValidPosition(Vector3Int position)
   {
      return entrophieLevelMap.GetLength(0) <= position.y ||
              entrophieLevelMap.GetLength(1) <= position.x ||
              position.x < 0 ||
              position.y < 0;
   }

   public Tile getRandomTile()
   {
      return tiles[UnityEngine.Random.Range(0, tiles.Count)];
   }

   public Vector3Int getLeastEntrophiePosition()
   {
      int entropieLevel = 999;
      Vector3Int position = new Vector3Int();

      for (int y = 0; y < height; y++)
      {
         for (int x = 0; x < width; x++)
         {
            if (entrophieLevelMap[y, x] <= entropieLevel && entrophieLevelMap[y, x] != -1)
            {
               entropieLevel = entrophieLevelMap[y, x];
               position = new Vector3Int(x, y);
            }
         }
      }

      if (entropieLevel == 0)
         Debug.LogError("entropie Level should never be 0 if so then something should be done");

      return position;
   }

   public Tile getTileByTileBase(TileBase tileBase)
   {
      return tiles.Find((tile) =>
      {
         return tile.tile == tileBase;
      });
   }

   public void addPossibleTiles(List<ChanceTile> tiles)
   {
      if (tiles == null)
         return;

      possibleTiles_copy = possibleTiles_copy.Intersect(tiles).ToList();

      // foreach (var item in possibleTiles_copy)
      // {
      //    Debug.Log(item.tile.name);
      // }
   }

   public void restartPossibleTiles()
   {
      possibleTiles_copy.AddRange(possibleTiles);
   }

   public List<ChanceTile> getPossibleTiles()
   {
      return possibleTiles_copy;
   }

   public void printEntropieMap()
   {
      string testStr = "";

      for (int y = height - 1; y >= 0; y--)
      {
         for (int x = 0; x < width; x++)
         {
            testStr += entrophieLevelMap[y, x] + " ";
         }
         Debug.Log(testStr);
         testStr = "";
      }
   }
}
