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

    [SerializeField] int speedInMilliSeconds = 0;

    PossibleTilesMap map;

    [SerializeField] Tilemap tilemap;

    [Button("Generate World", 32)]
    public void _GenerateWorld() => generateWorld();

    [Button("Delete World")]
    public void _DeleteWorld() => deleteWorld();

    // List<ChanceTile> possibleTiles = new List<ChanceTile>();

    [Title("Testing", 30)]
    [SerializeField] Vector3Int testPosition;

    private void Start()
    {
        generateWorld();
    }

    private void init()
    {
        map = new PossibleTilesMap(width, height, tiles);

        // map.printEntropieMap();
    }

    public async void generateWorld()
    {
        deleteWorld();
        init();

        // // select random position
        Vector3Int position = map.getRandomPosition();

        // // set random tile

        setTile(position, map.getRandomTile().tile);

        // calculate entrophie (what kind of tile it can be at begin all are lenght of tile array)
        calculateEntrophie(position);

        // [loop until no empty fields]
        for (int i = 0; i < map.width * map.height - 1; i++)
        {
            await Task.Delay(speedInMilliSeconds);

            // select least entrophie tile
            Vector3Int entrophiePosition = map.getLeastEntrophiePosition();

            // collapse it to one of the random neighbors
            collapseTile(entrophiePosition);
            // restart loop
        }
    }

    private void setTile(Vector3Int position, TileBase tile)
    {
        tilemap.SetTile(position, tile);
        map.updateEntrophieMap(position, -1);
    }

    private void calculateEntrophie(Vector3Int position)
    {
        int newEntrophie;
        TileBase tileBase = tilemap.GetTile(position);

        newEntrophie = map.getTileByTileBase(tileBase).topNeighbors.Count();
        map.updateEntrophieMap(new Vector3Int(position.x, position.y + 1), newEntrophie);

        newEntrophie = map.getTileByTileBase(tileBase).rightNeighbors.Count();
        map.updateEntrophieMap(new Vector3Int(position.x + 1, position.y), newEntrophie);

        newEntrophie = map.getTileByTileBase(tileBase).bottomNeighbors.Count();
        map.updateEntrophieMap(new Vector3Int(position.x, position.y - 1), newEntrophie);

        newEntrophie = map.getTileByTileBase(tileBase).leftNeighbors.Count();
        map.updateEntrophieMap(new Vector3Int(position.x - 1, position.y), newEntrophie);
    }

    public void deleteWorld()
    {
        tilemap.ClearAllTiles();
    }

    // ich muss machen dass nur die Tiles in possibleTiles gespeichert werden die in allen teilen vorhanden sind 
    // nicht jede nur einmal

    public void collapseTile(Vector3Int position)
    {
        map.restartPossibleTiles();

        // Debug.LogError(position.ToString());
        List<ChanceTile> bottomNeighbors = map.getTileByTileBase(tilemap.GetTile(Vector3Int.up + position))?.bottomNeighbors;
        List<ChanceTile> leftNeighbors = map.getTileByTileBase(tilemap.GetTile(Vector3Int.right + position))?.leftNeighbors;
        List<ChanceTile> rightNeighbors = map.getTileByTileBase(tilemap.GetTile(Vector3Int.left + position))?.rightNeighbors;
        List<ChanceTile> topNeighbors = map.getTileByTileBase(tilemap.GetTile(Vector3Int.down + position))?.topNeighbors;

        map.addPossibleTiles(bottomNeighbors);
        map.addPossibleTiles(leftNeighbors);
        map.addPossibleTiles(rightNeighbors);
        map.addPossibleTiles(topNeighbors);

        float weight = 0f;
        List<float> weightList = new List<float>();

        List<ChanceTile> possibleTiles = map.getPossibleTiles();

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
}