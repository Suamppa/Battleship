using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
}
