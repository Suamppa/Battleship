using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShipNumberSlider : MonoBehaviour
{
    private Slider slider;
    private TextMeshProUGUI handleText;

    private void Start() {
        slider = GetComponent<Slider>();
        handleText = GetComponentInChildren<TextMeshProUGUI>();
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnSliderValueChanged(float value) {
        handleText.text = value.ToString();
    }

    // Update slider bounds based on the selected board size
    // The area of the grid should be at least twice the total area of the ships
    public void UpdateBounds(int boardSizeX, int boardSizeY) {
        int maxShipArea = boardSizeX * boardSizeY / 2;
    }
}
