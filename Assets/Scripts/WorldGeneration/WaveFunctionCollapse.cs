using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity.Mathematics;
using Unity.Properties;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Tilemaps;
using EditorAttributes;
using UnityEditor.Tilemaps;
using UnityEngine.Android;
using UnityEditor.PackageManager;

public class WaveFunctionCollapse : MonoBehaviour
{
    [SerializeField] int height;
    [SerializeField] int width;

    [SerializeField] int speedInMilliSeconds = 0;

    WFCMap map;

    [SerializeField] Tilemap tilemap;

    [Button("Generate World", 32)]
    public void _GenerateWorld() => generateWorld();

    [Button("Delete World")]
    public void _DeleteWorld() => deleteWorld();

    [Button("Test delete tiles around position")]
    public void _DeleteTilesAroundPosition() => deleteTilesAroundPosition(testPosition);

    [Button("calculate Entropie")]
    public void _calcEntropie() => calculateEntrophieToPosition(testPosition);

    [SerializeField] Tilemap tilemapSample;

    [Button("collapse Entropie", 32)]
    public void _testcollapse() => collapseTile(testPosition);

    [Title("Testing", 30)]
    [SerializeField] Vector3Int testPosition;
    [SerializeField] Texture2D image;

    private void Start()
    {
        generateWorld();
    }

    private void init()
    {
        // map = new WFCMap(width, height, tiles);

        // map.printEntropieMap();
    }

    public async void generateWorld()
    {
        deleteWorld();
        // init();

        // get all tiles

        tilemapSample.CompressBounds();

        List<TileBase> list = getTileBases();

        List<MultiNeighborTile> mntTiles = new List<MultiNeighborTile>();

        foreach (var item in list)
        {
            mntTiles.Add(new MultiNeighborTile(item));
        }

        foreach (var item in mntTiles)
        {
            Debug.Log(item);
        }

        Debug.LogWarning("positions: ");

        for (int i = 0; i < mntTiles.Count; i++)
        {
            foreach (var pos in getPositions(mntTiles[i].tile))
            {
                Debug.Log(pos);

                if (tilemapSample.GetTile(pos + Vector3Int.up) != null)
                    mntTiles[i].topNeighbors.Add(new ChanceTile(tilemapSample.GetTile(pos + Vector3Int.up)));

                if (tilemapSample.GetTile(pos + Vector3Int.right) != null)
                    mntTiles[i].rightNeighbors.Add(new ChanceTile(tilemapSample.GetTile(pos + Vector3Int.right)));

                if (tilemapSample.GetTile(pos + Vector3Int.down) != null)
                    mntTiles[i].bottomNeighbors.Add(new ChanceTile(tilemapSample.GetTile(pos + Vector3Int.down)));

                if (tilemapSample.GetTile(pos + Vector3Int.left) != null)
                    mntTiles[i].leftNeighbors.Add(new ChanceTile(tilemapSample.GetTile(pos + Vector3Int.left)));
            }
        }


        foreach (MultiNeighborTile tile in mntTiles)
        {
            Debug.Log(tile.tile.name);

            foreach (var item in tile.topNeighbors)
                Debug.Log("top\t" + item.tile);

            foreach (var item in tile.rightNeighbors)
                Debug.Log("right\t" + item.tile);

            foreach (var item in tile.bottomNeighbors)
                Debug.Log("bottom\t" + item.tile);

            foreach (var item in tile.leftNeighbors)
                Debug.Log("left\t" + item.tile);
        }

        map = new WFCMap(width, height, mntTiles);

        // select random position
        Vector3Int position = map.getRandomPosition();

        // set random tile

        setTile(position, map.getRandomTile().tile);

        // calculate entrophie (what kind of tile it can be at begin all are lenght of tile array)
        calculateEntrophie(position);

        // [loop until no empty fields]
        while (map.hasEmptyField())
        {
            await Task.Delay(speedInMilliSeconds);

            // select least entrophie tile
            Vector3Int entrophiePosition = map.getLeastEntrophiePosition();

            // collapse it to one of the random neighbors
            collapseTile(entrophiePosition);
            // restart loop

        }
    }

    private MultiNeighborTile getTileByTilebase(List<MultiNeighborTile> mntTiles, TileBase tileBase)
    {
        return mntTiles.Find((tile) =>
        {
            return tile.tile == tileBase;
        });
    }

    private List<TileBase> getTileBases()
    {
        HashSet<TileBase> mntTiles = new HashSet<TileBase>();

        foreach (var item in tilemapSample.GetTilesBlock(tilemapSample.cellBounds))
        {
            if (item != null)
            {
                Debug.Log(item);
                mntTiles.Add(item);
            }
        }

        return mntTiles.ToList();
    }

    private void setTile(Vector3Int position, TileBase tile)
    {
        tilemap.SetTile(position, tile);
        map.updateEntrophieMap(position, -1);
    }

    private List<Vector3Int> getPositions(TileBase tilebase)
    {
        List<Vector3Int> help = new List<Vector3Int>();

        foreach (var position in tilemapSample.cellBounds.allPositionsWithin)
        {
            Debug.Log(position);
            if (tilemapSample.GetTile(position) != null && tilemapSample.GetTile(position).Equals(tilebase))
            {
                Debug.LogWarning("Added tile at position " + position + " of tile " + tilebase);
                help.Add(position);
            }
        }

        return help;
    }

    private void calculateEntrophie(Vector3Int position)
    {
        int newEntrophie;
        TileBase tileBase = tilemap.GetTile(position);
        Tile tile = map.getTileByTileBase(tileBase);

        newEntrophie = tile.getTopNeighbor().Count();
        map.updateEntrophieMap(new Vector3Int(position.x, position.y + 1), newEntrophie);

        newEntrophie = tile.getRightNeighbor().Count();
        map.updateEntrophieMap(new Vector3Int(position.x + 1, position.y), newEntrophie);

        newEntrophie = tile.getBottomNeighbor().Count();
        map.updateEntrophieMap(new Vector3Int(position.x, position.y - 1), newEntrophie);

        newEntrophie = tile.getLeftNeighbor().Count();
        map.updateEntrophieMap(new Vector3Int(position.x - 1, position.y), newEntrophie);
    }

    private void calculateEntrophieToPosition(Vector3Int position)
    {

        map.restartPossibleTiles();

        Tile tileTop = map.getTileByTileBase(tilemap.GetTile(position + Vector3Int.up));
        Tile tileRight = map.getTileByTileBase(tilemap.GetTile(position + Vector3Int.right));
        Tile tileDown = map.getTileByTileBase(tilemap.GetTile(position + Vector3Int.down));
        Tile tileLeft = map.getTileByTileBase(tilemap.GetTile(position + Vector3Int.left));

        if (tileTop != null)
            map.addPossibleTiles(tileTop.getBottomNeighbor());
        if (tileRight != null)
            map.addPossibleTiles(tileRight.getLeftNeighbor());
        if (tileDown != null)
            map.addPossibleTiles(tileDown.getTopNeighbor());
        if (tileLeft != null)
            map.addPossibleTiles(tileLeft.getRightNeighbor());

        map.updateEntrophieMap(position, map.getPossibleTiles().Count);
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

        List<ChanceTile> bottomNeighbors = map.getTileByTileBase(tilemap.GetTile(Vector3Int.up + position))?.getBottomNeighbor();
        List<ChanceTile> leftNeighbors = map.getTileByTileBase(tilemap.GetTile(Vector3Int.right + position))?.getLeftNeighbor();
        List<ChanceTile> rightNeighbors = map.getTileByTileBase(tilemap.GetTile(Vector3Int.left + position))?.getRightNeighbor();
        List<ChanceTile> topNeighbors = map.getTileByTileBase(tilemap.GetTile(Vector3Int.down + position))?.getTopNeighbor();

        map.addPossibleTiles(bottomNeighbors);
        map.addPossibleTiles(leftNeighbors);
        map.addPossibleTiles(rightNeighbors);
        map.addPossibleTiles(topNeighbors);


        List<ChanceTile> possibleTiles = map.getPossibleTiles();

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
        map.updateEntrophieMap(newPosition, -2);

        newPosition = position + Vector3Int.right;
        tilemap.SetTile(newPosition, null);
        map.updateEntrophieMap(newPosition, -2);

        newPosition = position + Vector3Int.down;
        tilemap.SetTile(newPosition, null);
        map.updateEntrophieMap(newPosition, -2);

        newPosition = position + Vector3Int.left;
        tilemap.SetTile(newPosition, null);
        map.updateEntrophieMap(newPosition, -2);
    }
}