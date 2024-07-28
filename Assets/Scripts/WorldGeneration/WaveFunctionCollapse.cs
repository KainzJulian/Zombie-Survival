using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EditorAttributes;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WaveFunctionCollapse : MonoBehaviour
{

    [SerializeField] List<Tile> tiles = new List<Tile>();
    [SerializeField] int height;
    [SerializeField] int width;

    int[,] entrophieLevelMap;

    [SerializeField] Tilemap tilemap;

    [Button("Generate World", 32)]
    public void _GenerateWorld() => generateWorld();

    [Button("Delete World")]
    public void _DeleteWorld() => deleteWorld();

    [Button("Print Entropie Map")]
    public void _PrintEntropieMap() => printEntropieMap();

    HashSet<int> possibleTiles = new HashSet<int>();


    private void Start()
    {
        generateWorld();
    }

    private void init()
    {
        entrophieLevelMap = new int[height, width];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                entrophieLevelMap[y, x] = tiles.Count;
            }
        }

        printEntropieMap();
    }

    private void printEntropieMap()
    {
        string testStr = "";

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                testStr += entrophieLevelMap[y, x] + " ";
            }
            Debug.Log(testStr);
            testStr = "";
        }
    }

    private void updateEntrophieMap(Vector3Int position, int newValue)
    {
        if (entrophieLevelMap.GetLength(0) > position.y || entrophieLevelMap.GetLength(1) > position.x)
            return;

        entrophieLevelMap[position.x, position.y] = newValue;
    }

    private int getEntrophie(Vector3Int position)
    {
        return entrophieLevelMap[position.x, position.y];
    }


    [Title("Testing", 30)]
    [SerializeField] Vector3Int testPosition;

    [Button("get Field Neighbors")]
    public void _test() => printField();


    public void generateWorld()
    {
        deleteWorld();
        init();

        // select random position
        Vector3Int position = randomPosition();

        // set random tile

        setTile(position, getRandomTile().tile);

        // [loop until no empty fields]
        // calculate entrophie (what kind of tile it can be at begin all are lenght of tile array)

        calculateEntrophie(position);

        // select least entrophie tile
        // collapse it to one of the random neighbors
        // restart loop


    }

    private void setTile(Vector3Int position, TileBase tile)
    {
        tilemap.SetTile(position, getRandomTile().tile);
        updateEntrophieMap(position, -1);
    }

    private void addPossibleTiles(ChanceTile[] tiles)
    {
        foreach (ChanceTile item in tiles)
        {
            possibleTiles.Add(item.tile.id);
        }
    }

    private void calculateEntrophie(Vector3Int position)
    {
        int newEntrophie;
        TileBase tileBase = tilemap.GetTile(position);

        newEntrophie = getTileByTileBase(tileBase).topNeighbors.Count();
        updateEntrophieMap(new Vector3Int(position.x, position.y + 1), newEntrophie);

        newEntrophie = getTileByTileBase(tileBase).rightNeighbors.Count();
        updateEntrophieMap(new Vector3Int(position.x + 1, position.y), newEntrophie);

        newEntrophie = getTileByTileBase(tileBase).bottomNeighbors.Count();
        updateEntrophieMap(new Vector3Int(position.x, position.y - 1), newEntrophie);

        newEntrophie = getTileByTileBase(tileBase).leftNeighbors.Count();
        updateEntrophieMap(new Vector3Int(position.x - 1, position.y), newEntrophie);

    }

    public void printField()
    {
        Tile top = getTileByTileBase(tilemap.GetTile(Vector3Int.up + testPosition));
        Tile right = getTileByTileBase(tilemap.GetTile(Vector3Int.right + testPosition));
        Tile left = getTileByTileBase(tilemap.GetTile(Vector3Int.left + testPosition));
        Tile down = getTileByTileBase(tilemap.GetTile(Vector3Int.down + testPosition));
        Tile current = getTileByTileBase(tilemap.GetTile(testPosition));

        Debug.Log("----------");
        Debug.Log("     " + top.name);
        Debug.Log(left.name + "     " + current.name + "       " + right.name);
        Debug.Log("     " + down.name);
    }

    public Tile getTileByTileBase(TileBase tileBase)
    {
        return tiles.Find((tile) =>
        {
            return tile.tile == tileBase;
        });
    }

    public void deleteWorld()
    {
        tilemap.ClearAllTiles();
    }

    private Tile getRandomTile()
    {
        return tiles[UnityEngine.Random.Range(0, tiles.Count)];
    }

    private Vector3Int randomPosition()
    {
        return new Vector3Int(
            UnityEngine.Random.Range(0, width),
            UnityEngine.Random.Range(0, height)
        );
    }

    public TileBase getRandomTileNeighbor(Tile neighbor)
    {
        // float weight = 0f;
        // List<float> weightList = new List<float>();

        // foreach (Tile chance in neighbor.neighbors)
        // {
        //     weight += chance.spawnChance;
        //     weightList.Add(weight);
        // }

        // float randomValue = UnityEngine.Random.Range(0, weight);

        // for (int i = 0; i < weightList.Count; i++)
        // {
        //     if (randomValue < weightList[i])
        //         return neighbor.neighbors[i].tile;
        // }

        return neighbor.tile;
    }
}