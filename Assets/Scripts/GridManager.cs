using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour {
    private Tilemap[] layers;
    // The size of the board
    private int boardSizeX, boardSizeY;

    public GameOptionsProvider gameOptions;
    // The grid of the game board
    public int[,] GameBoard { get; private set; }
    // Optional reference to a camera to set to the center of the board
    public Transform sceneCamera;

    private void Awake() {
        layers = GetComponentsInChildren<Tilemap>();
        if (layers == null) {
            Debug.LogError("No Tilemap components found.");
        }
    }

    private void Start() {
        UpdateBoardSize();
        ClearBoard();
    }

    private void UpdateBoardSize() {
        boardSizeX = gameOptions.BoardWidth;
        boardSizeY = gameOptions.BoardHeight;
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
        foreach (Tilemap layer in layers) {
            TileBase tile = layer.GetTile(new Vector3Int(0, 0, 0));
            Debug.Log("Drawing layer " + layer.name + " with tile " + tile.name);
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
        if (sceneCamera != null) {
            Vector3 newPosition = new((boardSizeX / 2f) + cameraOffsetX, (boardSizeY / 2f) + cameraOffsetY, sceneCamera.position.z);
            sceneCamera.position = newPosition;
        }
    }
}
