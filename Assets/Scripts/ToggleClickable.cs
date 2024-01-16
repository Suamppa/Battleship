using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ToggleClickable : MonoBehaviour
{
    private Button button;
    private TextMeshProUGUI buttonText;

    // Is the button clickable initially
    public bool clickable = false;
    // The alpha value (opacity) of the button text when enabled/disabled
    public float enabledAlpha = 1f;
    public float disabledAlpha = 0.5f;

    private void Awake() {
        button = GetComponent<Button>();
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
        if (buttonText == null) {
            Debug.LogError("TextMeshProUGUI component is missing");
            return;
        }
    }

    private void Start() {
        if (clickable) { 
            Enable();
        } else {
            Disable();
        }
    }

    public void Toggle() {
        if (button.interactable) {
            Disable();
        } else {
            Enable();
        }
    }

    public void Disable() {
        button.interactable = false;
        buttonText.alpha = disabledAlpha;
    }

    public void Enable() {
        button.interactable = true;
        buttonText.alpha = enabledAlpha;
    }
}
