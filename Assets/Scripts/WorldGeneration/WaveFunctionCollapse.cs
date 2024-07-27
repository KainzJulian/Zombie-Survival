using System;
using System.Collections;
using System.Collections.Generic;
using EditorAttributes;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WaveFunctionCollapse : MonoBehaviour
{

    [SerializeField] List<Tile> tiles = new List<Tile>();
    [SerializeField] int height;
    [SerializeField] int width;

    [SerializeField] Tilemap tilemap;

    [Button("Generate World", 32)]
    public void _GenerateWorld() => generateWorld();

    [Button("Delete World")]
    public void _DeleteWorld() => deleteWorld();

    public int testvalue;

    TileBase currentTile;

    private void Start()
    {
        generateWorld();
    }

    [Title("Testing", 30)]
    [SerializeField] Vector3Int testPosition;

    [Button("get Field Neighbors")]
    public void _test() => printField();


    public void generateWorld()
    {
        deleteWorld();
        currentTile = getRandomTile().tile;

        Debug.Log("loading world");
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                test(x, y);
                tilemap.SetTile(new Vector3Int(x, y), currentTile);
                Debug.Log(currentTile.name);
            }

        }
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

    public void test(int x, int y)
    {
        Vector3Int position = new Vector3Int(x, y);
        // Tile top = getTileByTileBase(tilemap.GetTile(Vector3Int.up + position));
        // Tile right = getTileByTileBase(tilemap.GetTile(Vector3Int.right + position));
        Tile left = getTileByTileBase(tilemap.GetTile(Vector3Int.left + position));
        Tile down = getTileByTileBase(tilemap.GetTile(Vector3Int.down + position));

        // int topVal = 0;
        // int rightVal = 0;
        int leftVal = 0;
        int downVal = 0;

        int counter = 0;

        if (down != null)
        {
            downVal = down.value;
            counter++;
        }

        // if (top != null)
        // {
        //     topVal = top.value;
        //     counter++;
        // }

        // if (right != null)
        // {
        //     rightVal = right.value;
        //     counter++;
        // }

        if (left != null)
        {
            leftVal = left.value;
            counter++;
        }

        int help = 0;

        // Debug.LogWarning("Values: ");
        // Debug.Log(topVal);
        // Debug.Log(rightVal);
        // Debug.Log(leftVal);
        // Debug.Log(downVal);

        if (counter != 0)
            help = (int)Mathf.Floor((downVal + leftVal) / counter);
        Debug.LogWarning("Printing Help");
        Debug.Log(help);

        Debug.Log(help);
        if (help == 0)
        {
            currentTile = getRandomTile().tile;
            return;
        }

        Tile tile = getTileByValue(help);



    }

    public Tile getTileByTileBase(TileBase tileBase)
    {
        return tiles.Find((tile) =>
        {
            return tile.tile == tileBase;
        });
    }

    public Tile getTileByValue(int value)
    {
        return tiles.Find((tile) =>
        {
            return tile.value == value;
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

    public TileBase getRandomTileNeighbor(Tile neighbor)
    {
        float weight = 0f;
        List<float> weightList = new List<float>();

        foreach (Tile chance in neighbor.neighbors)
        {
            weight += chance.spawnChance;
            weightList.Add(weight);
        }

        float randomValue = UnityEngine.Random.Range(0, weight);

        for (int i = 0; i < weightList.Count; i++)
        {
            if (randomValue < weightList[i])
                return neighbor.neighbors[i].tile;
        }

        return neighbor.tile;
    }
}