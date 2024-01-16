using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Dropdown))]
public class BoardSizeDropdown : MonoBehaviour
{
    private const int MinValue = 5;
    private TMP_Dropdown dropdown;

    public int Value { get; private set; } = MinValue;

    // Event to replace TMP_Dropdown.onValueChanged to ensure the value is always correct
    public event Action OnValueChanged;

    private void Awake() {
        dropdown = GetComponent<TMP_Dropdown>();
    }

    private void Start() {
        dropdown.onValueChanged.AddListener(UpdateValue);
    }

    private void OnDestroy() {
        dropdown.onValueChanged.RemoveListener(UpdateValue);
    }

    private void UpdateValue(int value) {
        // Dropdown value is 0-indexed, so add the minimum value to get the actual value
        Value = value + MinValue;
        Debug.Log($"{gameObject.name} value: {Value}");

        OnValueChanged?.Invoke();
    }
}
