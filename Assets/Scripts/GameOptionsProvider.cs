using System.Collections.Generic;
using UnityEngine;

// An intermediary class for bundling up the selected options from the UI elements
public class GameOptionsProvider : MonoBehaviour
{
    private const string BoardWidthKey = "boardWidth";
    private const string BoardHeightKey = "boardHeight";
    private const string NumberOfShipsKey = "numberOfShips";

    // Dictionary for holding the game options as a collection
    private static Dictionary<string, int> gameOptions;

    // Singleton instance
    public static GameOptionsProvider Instance { get; private set; }

    public const int minBoardLength = 5;
    public const int minNumberOfShips = 1;

    // Individual properties for the game options
    public static int BoardWidth { get; private set; } = minBoardLength;
    public static int BoardHeight { get; private set; } = minBoardLength;
    public static int NumberOfShips { get; private set; } = minNumberOfShips;

    public BoardSizeDropdown boardWidthDropdown, boardHeightDropdown;
    public ShipNumberSlider shipNumberSlider;

    private void Awake() {
        // If the singleton hasn't been initialized yet
        if (Instance == null) {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        gameOptions = new() {
            {BoardWidthKey, BoardWidth},
            {BoardHeightKey, BoardHeight},
            {NumberOfShipsKey, NumberOfShips}
        };
    }
    
    public static void UpdateGameOptions() {
        BoardWidth = Instance.boardWidthDropdown.Value;
        BoardHeight = Instance.boardHeightDropdown.Value;
        NumberOfShips = Instance.shipNumberSlider.Value;

        gameOptions[BoardWidthKey] = BoardWidth;
        gameOptions[BoardHeightKey] = BoardHeight;
        gameOptions[NumberOfShipsKey] = NumberOfShips;
        
        Debug.Log($"Game options updated");
    }

    public static Dictionary<string, int> GetGameOptions() {
        UpdateGameOptions();
        return gameOptions;
    }
}
