using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour {
    private Tilemap[] layers;
    // The size of the board
    private int boardSizeX, boardSizeY;
    private Camera mainCamera;

    // The grid of the game board
    public int[,] GameBoard { get; private set; }

    // The tiles to use for each layer
    public TileBase[] tiles;

    private void Awake() {
        layers = GetComponentsInChildren<Tilemap>();
        if (layers == null) {
            Debug.LogError("No Tilemap components found.");
        }
        mainCamera = Camera.main;
    }

    private void Start() {
        if (tiles.Length < layers.Length) {
            Debug.LogError("Not enough tiles for the layers.");
        }
        UpdateBoardSize();
        ClearBoard();
    }

    private void UpdateBoardSize() {
        boardSizeX = GameOptionsProvider.BoardWidth;
        boardSizeY = GameOptionsProvider.BoardHeight;
    }

    private void InitializeBoard() {
        GameBoard = new int[boardSizeX, boardSizeY];
        for (int x = 0; x < boardSizeX; x++) {
            for (int y = 0; y < boardSizeY; y++) {
                GameBoard[x, y] = 0;
            }
        }
    }

    private void ClearLayer(Tilemap tilemap) {
        tilemap.ClearAllTiles();
    }

    private void DrawLayer(Tilemap tilemap, TileBase tile) {
        for (int x = 0; x < boardSizeX; x++) {
            for (int y = 0; y < boardSizeY; y++) {
                Vector3Int tilePosition = new(x, y, 0);
                tilemap.SetTile(tilePosition, tile);
            }
        }
    }

    public void DrawBoard() {
        ClearBoard();
        UpdateBoardSize();
        InitializeBoard();
        for (int i = 0; i < layers.Length; i++) {
            Tilemap layer = layers[i];
            TileBase tile = tiles[i];
            Debug.Log($"Drawing layer {layer.name} with tile {tile.name}");
            DrawLayer(layer, tile);
        }

        AlignCamera();
    }

    public void ClearBoard() {
        foreach (Tilemap layer in layers) {
            ClearLayer(layer);
        }
    }

    public void AlignCamera(float cameraOffsetX = 0f, float cameraOffsetY = 0f) {
        if (mainCamera != null) {
            float x = (boardSizeX / 2f) + cameraOffsetX;
            float y = (boardSizeY / 2f) + cameraOffsetY;
            float z = mainCamera.transform.position.z;
            Vector3 newPosition = new(x, y, z);
            mainCamera.transform.position = newPosition;
        }
    }
}
