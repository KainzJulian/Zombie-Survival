using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EditorAttributes;
using Unity.Mathematics;
using Unity.Properties;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;
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

    [Button("Test HashSet")]
    public void _TestHashSet() => testHashSet();


    List<ChanceTile> possibleTiles = new List<ChanceTile>();

    [Title("Testing", 30)]
    [SerializeField] Vector3Int testPosition;

    [Button("get Field Neighbors")]
    public void _test() => printField();

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

    private void updateEntrophieMap(Vector3Int position, int newValue)
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

    public async void generateWorld()
    {
        deleteWorld();
        init();

        // select random position
        Vector3Int position = getRandomPosition();

        // set random tile

        setTile(position, getRandomTile().tile);

        // calculate entrophie (what kind of tile it can be at begin all are lenght of tile array)
        calculateEntrophie(position);

        // [loop until no empty fields]
        for (int i = 0; i < width * height - 1; i++)
        {
            await Task.Delay(300);

            // select least entrophie tile
            Vector3Int entrophiePosition = getLeastEntrophiePosition();

            // collapse it to one of the random neighbors
            collapseTile(entrophiePosition);
            // restart loop
        }


    }

    private Vector3Int getLeastEntrophiePosition()
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
        return position;
    }


    private void setTile(Vector3Int position, TileBase tile)
    {
        tilemap.SetTile(position, tile);
        updateEntrophieMap(position, -1);
    }


    private void testHashSet()
    {
        addPossibleTiles(tiles[1].topNeighbors);
        addPossibleTiles(tiles[1].bottomNeighbors);
        addPossibleTiles(tiles[1].rightNeighbors);
        addPossibleTiles(tiles[1].leftNeighbors);

        Assert.AreEqual(2, possibleTiles.Count);
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

    private Vector3Int getRandomPosition()
    {
        return new Vector3Int(
            UnityEngine.Random.Range(0, width),
            UnityEngine.Random.Range(0, height)
        );
    }

    // ich muss machen dass nur die Tiles in possibleTiles gespeichert werden die in allen teilen vorhanden sind 
    // nicht jede nur einmal
    private void addPossibleTiles(List<ChanceTile> tiles)
    {
        if (tiles == null)
            return;

        possibleTiles = possibleTiles.Intersect(tiles).ToList();

        foreach (var item in possibleTiles)
        {
            Debug.Log(item.tile.name);
        }
    }

    public void collapseTile(Vector3Int position)
    {
        // possibleTiles.AddRange(tiles[0].topNeighbors);
        // possibleTiles.AddRange(tiles[1].topNeighbors);
        // possibleTiles.AddRange(tiles[2].topNeighbors);

        Debug.LogError(position.ToString());
        List<ChanceTile> bottomNeighbors = getTileByTileBase(tilemap.GetTile(Vector3Int.up + position))?.bottomNeighbors;
        List<ChanceTile> leftNeighbors = getTileByTileBase(tilemap.GetTile(Vector3Int.right + position))?.leftNeighbors;
        List<ChanceTile> rightNeighbors = getTileByTileBase(tilemap.GetTile(Vector3Int.left + position))?.rightNeighbors;
        List<ChanceTile> topNeighbors = getTileByTileBase(tilemap.GetTile(Vector3Int.down + position))?.topNeighbors;

        addPossibleTiles(bottomNeighbors);
        addPossibleTiles(leftNeighbors);
        addPossibleTiles(rightNeighbors);
        addPossibleTiles(topNeighbors);
        // Debug.Log("                 top          right          left         down");
        // Debug.Log("ChanceTiles: " + bottomNeighbors + "  " + leftNeighbors + "  " + rightNeighbors + "  " + topNeighbors);



        Debug.Log("possible Tiles");
        foreach (var item in possibleTiles)
        {
            Debug.LogWarning(item.tile.id);
        }

        if (possibleTiles.Count == 2)
        {
            Debug.LogError("2 Tiles");
        }

        float weight = 0f;
        List<float> weightList = new List<float>();

        foreach (ChanceTile tile in possibleTiles)
        {
            weight += tile.spawnChance;
            weightList.Add(weight);
        }

        float randomValue = UnityEngine.Random.Range(0, weight);

        int counter = 0;

        foreach (ChanceTile chanceTile in possibleTiles)
        {
            if (randomValue < weightList[counter])
            {
                setTile(position, chanceTile.tile.tile);
                break;
            }
            counter++;
        }

        calculateEntrophie(position);
    }

    private static List<ChanceTile> setPossibleTiles(IEnumerable<ChanceTile> intersect)
    {
        return intersect.ToList();
    }
}