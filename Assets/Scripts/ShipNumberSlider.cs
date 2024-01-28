using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class ShipNumberSlider : MonoBehaviour
{
    // The smallest ship takes 2 cells per ship
    private const int MinShipSize = 2;

    private Slider slider;
    private TextMeshProUGUI handleText;

    public int Value
    {
        get => (int) slider.value;
        private set => slider.value = value;
    }
    public int MaxShipArea { get; private set; }

    public BoardSizeDropdown boardWidthDropdown, boardHeightDropdown;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        handleText = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        slider.onValueChanged.AddListener(OnSliderValueChanged);
        boardWidthDropdown.OnValueChanged += UpdateBounds;
        boardHeightDropdown.OnValueChanged += UpdateBounds;

        UpdateBounds();
    }

    private void OnEnable()
    {
        OnSliderValueChanged(Value);
        UpdateBounds();
    }

    private void OnDestroy()
    {
        slider.onValueChanged.RemoveListener(OnSliderValueChanged);
        boardWidthDropdown.OnValueChanged -= UpdateBounds;
        boardHeightDropdown.OnValueChanged -= UpdateBounds;
    }

    private void OnSliderValueChanged(float value)
    {
        handleText.text = value.ToString();
    }

    // Update slider bounds based on the selected board size
    // The area of the grid should be at least twice the total area of the ships
    public void UpdateBounds()
    {
        CalculateShipArea();
        UpdateSliderMax();
    }

    private void UpdateSliderMax()
    {
        // The maximum number of ships that can fit on the board
        int maxShipNumber = MaxShipArea / MinShipSize;
        // If the current value is greater than the new max, set it to the new max
        if (Value > maxShipNumber)
        {
            Value = maxShipNumber;
        }
        slider.maxValue = maxShipNumber;
    }

    // Calculate the maximum area the ships can take up on the board
    private void CalculateShipArea()
    {
        int boardWidth = boardWidthDropdown.Value;
        int boardHeight = boardHeightDropdown.Value;
        int area = boardWidth * boardHeight;
        Debug.Log($"Board area: {boardWidth} * {boardHeight} = {area}");
        MaxShipArea = area / 2;
    }
}
