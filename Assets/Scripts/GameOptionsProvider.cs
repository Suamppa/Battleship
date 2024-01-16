using System.Collections.Generic;
using UnityEngine;

// An intermediary class for bundling up the selected options from the UI elements
public class GameOptionsProvider : MonoBehaviour
{
    private const string BoardWidthKey = "boardWidth";
    private const string BoardHeightKey = "boardHeight";
    private const string NumberOfShipsKey = "numberOfShips";

    // Dictionary for holding the game options as a collection
    private Dictionary<string, int> gameOptions;

    // Singleton instance
    public static GameOptionsProvider Instance { get; private set; }

    public BoardSizeDropdown boardWidthDropdown, boardHeightDropdown;
    public ShipNumberSlider shipNumberSlider;

    // Individual properties for the game options
    public int BoardWidth => boardWidthDropdown.Value;
    public int BoardHeight => boardHeightDropdown.Value;
    public int NumberOfShips => shipNumberSlider.Value;

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
    
    public void UpdateGameOptions() {
        gameOptions[BoardWidthKey] = BoardWidth;
        gameOptions[BoardHeightKey] = BoardHeight;
        gameOptions[NumberOfShipsKey] = NumberOfShips;
    }

    public Dictionary<string, int> GetGameOptions() {
        UpdateGameOptions();
        return gameOptions;
    }
}
