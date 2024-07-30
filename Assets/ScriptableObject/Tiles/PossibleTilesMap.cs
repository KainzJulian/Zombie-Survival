using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class PossibleTilesMap
{
   public int[,] entrophieLevelMap;
   public int[,,] chanceTileMap;

   public HashSet<ChanceTile> possibleTiles = new HashSet<ChanceTile>();
   private List<ChanceTile> possibleTiles_copy = new List<ChanceTile>();

   public List<Tile> tiles;

   public int width
   {
      get
      {
         return chanceTileMap.GetLength(2);
      }
      private set { }
   }

   public int height
   {
      get
      {
         return chanceTileMap.GetLength(1);
      }
      private set { }
   }

   // public int depth
   // {
   //     get
   //     {
   //         return chanceTileMap.GetLength(0);
   //     }
   //     private set { }
   // }


   public PossibleTilesMap(int width, int height, List<Tile> tiles)
   {
      foreach (Tile tile in tiles)
      {
         possibleTiles.AddRange(tile.topNeighbors);
         possibleTiles.AddRange(tile.rightNeighbors);
         possibleTiles.AddRange(tile.leftNeighbors);
         possibleTiles.AddRange(tile.bottomNeighbors);
      }

      if (possibleTiles.Count != tiles.Count())
      {
         Debug.LogWarning(possibleTiles.Count + "  " + tiles.Count());
         throw new Exception("There are too many ChanceTiles in the Tiles provided");
      }

      this.tiles = tiles;

      possibleTiles_copy = possibleTiles.ToList();

      chanceTileMap = new int[possibleTiles.Count, height, width];

      ChanceTile[] arr = possibleTiles.ToArray();

      for (int z = 0; z < possibleTiles.Count; z++)
         for (int y = 0; y < height; y++)
            for (int x = 0; x < width; x++)
               chanceTileMap[z, y, x] = arr[z].tile.id;

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

   #region print Statements
   public void printIDs()
   {
      string help = "";

      for (int z = 0; z < chanceTileMap.GetLength(0); z++)
      {
         for (int y = 0; y < chanceTileMap.GetLength(1); y++)
         {
            for (int x = 0; x < chanceTileMap.GetLength(2); x++)
            {
               help += chanceTileMap[z, y, x] + " ";
            }
            help += "\n";
         }
         Debug.Log(help);
         help = "";
      }
   }

   public void printEntropieMap()
   {
      string testStr = "";

      for (int y = chanceTileMap.GetLength(1) - 1; y >= 0; y--)
      {
         for (int x = 0; x < chanceTileMap.GetLength(2); x++)
         {
            testStr += entrophieLevelMap[y, x] + " ";
         }
         Debug.Log(testStr);
         testStr = "";
      }
   }
   #endregion
}
