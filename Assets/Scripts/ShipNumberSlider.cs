using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShipNumberSlider : MonoBehaviour
{
    private Slider slider;
    private TextMeshProUGUI handleText;
    // The smallest ship takes 2 cells per ship
    private const int ShipMinCellSize = 2;

    public TMP_Dropdown boardWidthDropdown;
    public TMP_Dropdown boardHeightDropdown;

    private void Start() {
        slider = GetComponent<Slider>();
        handleText = GetComponentInChildren<TextMeshProUGUI>();
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnDestroy() {
        slider.onValueChanged.RemoveListener(OnSliderValueChanged);
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
        int maxShipNumber = maxShipArea / ShipMinCellSize;
        if (slider.value > maxShipNumber)
        {
            slider.value = maxShipNumber;
        }
        slider.maxValue = maxShipNumber;
    }

    private int CalculateBoardArea()
    {
        // 5 is added to the dropdown value because the dropdown starts at 0
        int boardWidth = boardWidthDropdown.value + 5;
        int boardHeight = boardHeightDropdown.value + 5;
        return boardWidth * boardHeight;
    }
}
