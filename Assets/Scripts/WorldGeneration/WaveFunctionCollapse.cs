using System;
using System.Collections;
using System.Collections.Generic;
using EditorAttributes;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WaveFunctionCollapse : MonoBehaviour
{

    [SerializeField] Tile[] tiles;
    [SerializeField] int height;
    [SerializeField] int width;

    [SerializeField] Tilemap tilemap;

    [Button("Generate World", 32)]
    public void _GenerateWorld() => generateWorld();

    [Button("Delete World")]
    public void _DeleteWorld() => deleteWorld();

    private void Start()
    {
        generateWorld();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void generateWorld()
    {

        Debug.Log("loading world");
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                tilemap.SetTile(new Vector3Int(x, y), getRandomTile());
            }
        }
    }

    public void deleteWorld()
    {
        tilemap.ClearAllTiles();
    }

    private TileBase getRandomTile()
    {
        return tiles[UnityEngine.Random.Range(0, tiles.Length)].tile;
    }


}

[Serializable]
struct Tile
{
    public TileBase tile;
    public ChanceTile[] neighbors;
}

[Serializable]
struct ChanceTile
{
    public TileBase tile;

    [Range(0, 100)]
    public float spawnChance;
}