using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Tilemaps;
using EditorAttributes;

public class WaveFunctionCollapse : MonoBehaviour
{

    // TODO: add a boolean value to use singleneighborTiles instead of MultineighborTiles for the tilemapSample
    // TODO: add multiple tilemaps so only the tilemaps next to the player can be loaded => performance 
    [SerializeField] int height;
    [SerializeField] int width;

    [SerializeField] int speedInMilliSeconds = 0;

    WFCMap map;

    [SerializeField] Tilemap tilemap;
    [SerializeField] Tilemap tilemapSample;

    [Button("Generate World", 32)]
    public void _GenerateWorld() => generateWorld();

    [Button("Delete World")]
    public void _DeleteWorld() => deleteWorld();

    private void deleteWorld()
    {
        tilemap.ClearAllTiles();
    }


    private void Start()
    {
        generateWorld();
    }

    public async void generateWorld()
    {
        map = new WFCMap(width, height, tilemap, tilemapSample);
        map.deleteWorld();

        // select random position
        Vector3Int position = map.getRandomPosition();

        // set random tile

        map.setTile(position, map.getRandomTile().tile);

        // calculate entrophie (what kind of tile it can be at begin all are lenght of tile array)
        map.calculateEntrophie(position);

        // [loop until no empty fields]
        while (map.hasEmptyField())
        {
            await Task.Delay(speedInMilliSeconds);

            // select least entrophie tile
            Vector3Int entrophiePosition = map.getLeastEntrophiePosition();

            // collapse it to one of the random neighbors
            map.collapseTile(entrophiePosition);
            // restart loop

        }
    }
}