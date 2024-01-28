using TMPro;
using UnityEngine;

public class SpaceDisplay : MonoBehaviour
{
    private int SpaceLeft => GameOptionsProvider.MaxShipArea - GameBoard.ActiveBoard.CellsOccupied;

    private TMP_Text spaceDisplay;

    private void Awake()
    {
        spaceDisplay = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        GameOptionsProvider.OnGameOptionsUpdated += UpdateSpaceDisplay;
        // UpdateSpaceDisplay();
    }

    private void OnDestroy()
    {
        GameOptionsProvider.OnGameOptionsUpdated -= UpdateSpaceDisplay;
    }

    public void UpdateSpaceDisplay()
    {
        spaceDisplay.text = $"{SpaceLeft} / {GameOptionsProvider.MaxShipArea}";
        Debug.Log($"Space available: {spaceDisplay.text}");
    }
}
