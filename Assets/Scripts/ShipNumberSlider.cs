using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class ShipNumberSlider : MonoBehaviour
{
    private Slider slider;
    private TextMeshProUGUI handleText;
    // The smallest ship takes 2 cells per ship
    private const int ShipMinCellSize = 2;

    public int Value {
        get => (int) slider.value;
        private set => slider.value = value;
    }
    
    public BoardSizeDropdown boardWidthDropdown, boardHeightDropdown;

    private void Awake() {
        slider = GetComponent<Slider>();
        handleText = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start() {
        slider.onValueChanged.AddListener(OnSliderValueChanged);
        boardWidthDropdown.OnValueChanged += UpdateBounds;
        boardHeightDropdown.OnValueChanged += UpdateBounds;

        UpdateBounds();
    }

    private void OnDestroy() {
        slider.onValueChanged.RemoveListener(OnSliderValueChanged);
        boardWidthDropdown.OnValueChanged -= UpdateBounds;
        boardHeightDropdown.OnValueChanged -= UpdateBounds;
    }

    private void OnSliderValueChanged(float value) {
        handleText.text = value.ToString();
    }

    // Update slider bounds based on the selected board size
    // The area of the grid should be at least twice the total area of the ships
    public void UpdateBounds()
    {
        int boardArea = CalculateBoardArea();
        UpdateSliderMax(boardArea);
    }

    private void UpdateSliderMax(int boardArea)
    {
        // The maximum area the ships can take up on the board
        int maxShipArea = boardArea / 2;
        // The maximum number of ships that can fit on the board
        int maxShipNumber = maxShipArea / ShipMinCellSize;
        // If the current value is greater than the new max, set it to the new max
        if (Value > maxShipNumber) {
            Value = maxShipNumber;
        }
        slider.maxValue = maxShipNumber;
    }

    private int CalculateBoardArea()
    {
        int boardWidth = boardWidthDropdown.Value;
        int boardHeight = boardHeightDropdown.Value;
        Debug.Log($"Board area: {boardWidth} * {boardHeight} = {boardWidth * boardHeight}");
        return boardWidth * boardHeight;
    }
}
