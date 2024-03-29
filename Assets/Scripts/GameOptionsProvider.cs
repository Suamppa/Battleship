using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// An intermediary class for bundling up the selected options from the UI elements
public class GameOptionsProvider : MonoBehaviour
{
    private const string BoardWidthKey = "boardWidth";
    private const string BoardHeightKey = "boardHeight";
    private const string MaxNumberOfShipsKey = "maxNumberOfShips";

    private static string playerOneName = PlayerOneDefaultName;
    private static string playerTwoName = PlayerTwoDefaultName;
    // Dictionary for holding the game options as a collection
    private static Dictionary<string, int> gameOptions;

    public static event Action OnGameOptionsUpdated;

    // Singleton instance
    public static GameOptionsProvider Instance { get; private set; }

    public const string PlayerOneDefaultName = "Player 1";
    public const string PlayerTwoDefaultName = "Player 2";
    public const int minBoardLength = 5;
    public const int minShipArea = minBoardLength * minBoardLength / 2;

    public static string PlayerOneName
    {
        get { return playerOneName; }
        set
        {
            playerOneName = value;
            OnGameOptionsUpdated?.Invoke();
        }
    }

    public static string PlayerTwoName
    {
        get { return playerTwoName; }
        set
        {
            playerTwoName = value;
            OnGameOptionsUpdated?.Invoke();
        }
    }
    
    // Individual properties for the game options
    public static int BoardWidth { get; private set; } = minBoardLength;
    public static int BoardHeight { get; private set; } = minBoardLength;
    public static int MaxShipArea { get; private set; } = minShipArea;

    public BoardSizeDropdown boardWidthDropdown, boardHeightDropdown;
    public ShipNumberSlider shipNumberSlider;

    private void Awake()
    {
        // If the singleton hasn't been initialized yet
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        gameOptions = new() {
            {BoardWidthKey, BoardWidth},
            {BoardHeightKey, BoardHeight},
            {MaxNumberOfShipsKey, MaxShipArea}
        };
    }

    public static void UpdateGameOptions()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0) return;

        BoardWidth = Instance.boardWidthDropdown.Value;
        BoardHeight = Instance.boardHeightDropdown.Value;
        MaxShipArea = Instance.shipNumberSlider.MaxShipArea;

        gameOptions[BoardWidthKey] = BoardWidth;
        gameOptions[BoardHeightKey] = BoardHeight;
        gameOptions[MaxNumberOfShipsKey] = MaxShipArea;

        OnGameOptionsUpdated?.Invoke();
        Debug.Log($"Game options updated: {BoardWidth}x{BoardHeight} board, {MaxShipArea} max ship area");
    }

    public static Dictionary<string, int> GetGameOptions()
    {
        UpdateGameOptions();
        return gameOptions;
    }
}
