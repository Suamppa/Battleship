using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour {
    // Set the size of the board
    public int boardSizeX;
    public int boardSizeY;
    // Set the tile to be used
    // public TileBase tile;
    // Optional reference to a camera to set to the center of the board
    public Transform sceneCamera;

    // Reference to the tilemap
    // private Tilemap tilemap;

    private void Start() {
        // tilemap = GetComponent<Tilemap>();
        Tilemap[] layers = GetComponentsInChildren<Tilemap>();
        foreach (Tilemap layer in layers) {
            TileBase tile = layer.GetTile(new Vector3Int(0, 0, 0));
            Debug.Log("Drawing layer " + layer.name + " with tile " + tile.name);
            GenerateBoard(layer, tile);
        }

        if (sceneCamera != null) {
            sceneCamera.position = new Vector3(boardSizeX / 2f, boardSizeY / 2f, -10);
        }
    }

    private void GenerateBoard(Tilemap tilemap, TileBase tile) {
        for (int x = 0; x < boardSizeX; x++) {
            for (int y = 0; y < boardSizeY; y++) {
                Vector3Int tilePosition = new(x, y, 0);
                tilemap.SetTile(tilePosition, tile);
            }
        }
    }
}
