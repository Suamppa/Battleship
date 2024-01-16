using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour {
    private Tilemap[] layers;

    // The grid of the game board
    public int[,] GameBoard { get; private set; }
    // Set the size of the board
    public int boardSizeX;
    public int boardSizeY;
    // Optional reference to a camera to set to the center of the board
    public Transform sceneCamera;

    private void Awake() {
        layers = GetComponentsInChildren<Tilemap>();
        if (layers == null) {
            Debug.LogError("No Tilemap components found.");
        }
    }

    private void Start() {
        InitializeBoard();
        foreach (Tilemap layer in layers) {
            TileBase tile = layer.GetTile(new Vector3Int(0, 0, 0));
            Debug.Log("Drawing layer " + layer.name + " with tile " + tile.name);
            DrawBoard(layer, tile);
        }

        if (sceneCamera != null) {
            sceneCamera.position = new Vector3(boardSizeX / 2f, boardSizeY / 2f, -10);
        }
    }

    private void InitializeBoard() {
        GameBoard = new int[boardSizeX, boardSizeY];
        for (int x = 0; x < boardSizeX; x++) {
            for (int y = 0; y < boardSizeY; y++) {
                GameBoard[x, y] = 0;
            }
        }
    }

    private void DrawBoard(Tilemap tilemap, TileBase tile) {
        for (int x = 0; x < boardSizeX; x++) {
            for (int y = 0; y < boardSizeY; y++) {
                Vector3Int tilePosition = new(x, y, 0);
                tilemap.SetTile(tilePosition, tile);
            }
        }
    }
}
