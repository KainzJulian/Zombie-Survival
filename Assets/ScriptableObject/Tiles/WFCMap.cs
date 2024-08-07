using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

[Serializable]
public class WFCMap
{
   public int[,] entrophieLevelMap;
   public IDTilesMap IDMap = new IDTilesMap();

   public HashSet<ChanceTile> possibleTiles = new HashSet<ChanceTile>();
   private List<ChanceTile> possibleTiles_copy = new List<ChanceTile>();

   public List<MultiNeighborTile> tiles;

   public int width;
   public int height;

   public Vector3Int currentPosition;

   public WFCMap(int width, int height, List<MultiNeighborTile> tiles)
   {
      this.width = width;
      this.height = height;

      foreach (Tile tile in tiles)
      {
         possibleTiles.AddRange(tile.getTopNeighbor());
         possibleTiles.AddRange(tile.getRightNeighbor());
         possibleTiles.AddRange(tile.getBottomNeighbor());
         possibleTiles.AddRange(tile.getLeftNeighbor());
      }

      if (possibleTiles.Count != tiles.Count())
      {

         Debug.LogWarning(possibleTiles.Count + "  " + tiles.Count());
         foreach (ChanceTile item in possibleTiles)
         {
            Debug.Log(item.tile);
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

      Vector3Int position = new Vector3Int(
          UnityEngine.Random.Range(0, width),
          UnityEngine.Random.Range(0, height)
      );

      currentPosition = position;

      return position;
   }

   public void updateEntrophieMap(Vector3Int position, int newValue)
   {
      if (isValidPosition(position))
         return;

      if (entrophieLevelMap[position.y, position.x] == -1 && newValue != -2)
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

      currentPosition = position;

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

   public int getEntropieCount(int entropie)
   {
      int help = 0;

      for (int y = 0; y < height; y++)
      {
         for (int x = 0; x < width; x++)
         {
            if (entrophieLevelMap[y, x] == entropie)
               help++;
         }
      }
      return help;
   }

   public bool hasEmptyField()
   {
      // Debug.Log("Entropie Count: " + getEntropieCount(-1));

      return getEntropieCount(-1) != width * height;
   }
}

[Serializable]
public class IDRowTiles
{
   public List<int> row = new List<int>();
}

[Serializable]
public class IDTilesMap
{
   public List<IDRowTiles> column = new List<IDRowTiles>();
}

