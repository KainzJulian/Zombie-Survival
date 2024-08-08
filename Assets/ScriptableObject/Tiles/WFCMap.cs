using System;
using System.Collections.Generic;
using System.Linq;
using EditorAttributes;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

[Serializable]
public class WFCMap
{
   [Button("Delete World")]
   public void _DeleteWorld() => deleteWorld();

   public int[,] entrophieLevelMap;

   public HashSet<ChanceTile> possibleTiles = new HashSet<ChanceTile>();
   private List<ChanceTile> possibleTiles_copy = new List<ChanceTile>();

   public List<MultiNeighborTile> tiles;

   public int width;
   public int height;

   public Vector3Int currentPosition;

   public Tilemap tilemap;
   public Tilemap tileSampleMap;

   public WFCMap(int width, int height, Tilemap tilemap, Tilemap tileSampleMap)
   {
      this.width = width;
      this.height = height;
      this.tilemap = tilemap;
      this.tileSampleMap = tileSampleMap;
      tiles = getUsedTilesInTilemap(tileSampleMap);

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
      return getEntropieCount(-1) != width * height;
   }

   public static List<MultiNeighborTile> getUsedTilesInTilemap(Tilemap tilemap)
   {
      tilemap.CompressBounds();

      List<TileBase> list = getTileBases(tilemap);

      List<MultiNeighborTile> mntTiles = new List<MultiNeighborTile>();

      foreach (var item in list)
      {
         mntTiles.Add(new MultiNeighborTile(item));
      }

      for (int i = 0; i < mntTiles.Count; i++)
      {
         foreach (var pos in getPositions(mntTiles[i].tile, tilemap))
         {
            if (tilemap.GetTile(pos + Vector3Int.up) != null)
               mntTiles[i].topNeighbors.Add(new ChanceTile(tilemap.GetTile(pos + Vector3Int.up)));

            if (tilemap.GetTile(pos + Vector3Int.right) != null)
               mntTiles[i].rightNeighbors.Add(new ChanceTile(tilemap.GetTile(pos + Vector3Int.right)));

            if (tilemap.GetTile(pos + Vector3Int.down) != null)
               mntTiles[i].bottomNeighbors.Add(new ChanceTile(tilemap.GetTile(pos + Vector3Int.down)));

            if (tilemap.GetTile(pos + Vector3Int.left) != null)
               mntTiles[i].leftNeighbors.Add(new ChanceTile(tilemap.GetTile(pos + Vector3Int.left)));
         }
      }

      return mntTiles;
   }

   public static List<TileBase> getTileBases(Tilemap tilemap)
   {
      HashSet<TileBase> tileBases = new HashSet<TileBase>();

      foreach (var item in tilemap.GetTilesBlock(tilemap.cellBounds))
      {
         if (item != null)
            tileBases.Add(item);
      }

      return tileBases.ToList();
   }

   public static List<Vector3Int> getPositions(TileBase tilebase, Tilemap tilemap)
   {
      List<Vector3Int> help = new List<Vector3Int>();

      foreach (var position in tilemap.cellBounds.allPositionsWithin)
      {
         if (tilemap.GetTile(position) != null && tilemap.GetTile(position).Equals(tilebase))
            help.Add(position);
      }

      return help;
   }

   public void deleteWorld()
   {
      tilemap.ClearAllTiles();
   }

   public void setTile(Vector3Int position, TileBase tile)
   {
      tilemap.SetTile(position, tile);
      updateEntrophieMap(position, -1);
   }

   public void calculateEntrophie(Vector3Int position)
   {
      int newEntrophie;
      TileBase tileBase = tilemap.GetTile(position);
      Tile tile = getTileByTileBase(tileBase);

      newEntrophie = tile.getTopNeighbor().Count();
      updateEntrophieMap(new Vector3Int(position.x, position.y + 1), newEntrophie);

      newEntrophie = tile.getRightNeighbor().Count();
      updateEntrophieMap(new Vector3Int(position.x + 1, position.y), newEntrophie);

      newEntrophie = tile.getBottomNeighbor().Count();
      updateEntrophieMap(new Vector3Int(position.x, position.y - 1), newEntrophie);

      newEntrophie = tile.getLeftNeighbor().Count();
      updateEntrophieMap(new Vector3Int(position.x - 1, position.y), newEntrophie);
   }

   public void collapseTile(Vector3Int position)
   {
      restartPossibleTiles();

      List<ChanceTile> bottomNeighbors = getTileByTileBase(tilemap.GetTile(Vector3Int.up + position))?.getBottomNeighbor();
      List<ChanceTile> leftNeighbors = getTileByTileBase(tilemap.GetTile(Vector3Int.right + position))?.getLeftNeighbor();
      List<ChanceTile> rightNeighbors = getTileByTileBase(tilemap.GetTile(Vector3Int.left + position))?.getRightNeighbor();
      List<ChanceTile> topNeighbors = getTileByTileBase(tilemap.GetTile(Vector3Int.down + position))?.getTopNeighbor();

      addPossibleTiles(bottomNeighbors);
      addPossibleTiles(leftNeighbors);
      addPossibleTiles(rightNeighbors);
      addPossibleTiles(topNeighbors);

      List<ChanceTile> possibleTiles = getPossibleTiles();

      if (possibleTiles.Count == 0)
      {
         deleteTilesAroundPosition(position);
         return;
      }

      // Debug.Log(possibleTiles.Count);

      float totalWeight = 0;

      foreach (var item in possibleTiles)
         totalWeight += item.weight;

      TileBase newTile = null;

      foreach (var item in possibleTiles)
      {
         if (UnityEngine.Random.Range(0f, totalWeight) < item.weight)
         {
            newTile = item.tile;
            break;
         }
         else
         {
            totalWeight -= item.weight;
         }
      }

      setTile(position, newTile);

      calculateEntrophie(position);
   }


   private void deleteTilesAroundPosition(Vector3Int position)
   {
      Vector3Int newPosition = position + Vector3Int.up;
      tilemap.SetTile(newPosition, null);
      updateEntrophieMap(newPosition, -2);

      newPosition = position + Vector3Int.right;
      tilemap.SetTile(newPosition, null);
      updateEntrophieMap(newPosition, -2);

      newPosition = position + Vector3Int.down;
      tilemap.SetTile(newPosition, null);
      updateEntrophieMap(newPosition, -2);

      newPosition = position + Vector3Int.left;
      tilemap.SetTile(newPosition, null);
      updateEntrophieMap(newPosition, -2);
   }
}


