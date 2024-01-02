using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToggleClickable : MonoBehaviour
{
    private Button button;
    private TextMeshProUGUI buttonText;

    private void Start() {
        button = GetComponent<Button>();
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
        Disable();
    }

    public void Toggle() {
        button.interactable = !button.interactable;

        // Set the button text colour transparency
        // Color textColor = buttonText.color;
        // textColor.a = button.interactable ? 1f : 0.5f;
        // buttonText.color = textColor;
        buttonText.alpha = button.interactable ? 1f : 0.5f;
    }

    public void Disable() {
        button.interactable = false;
        buttonText.alpha = 0.5f;
    }

    public void Enable() {
        button.interactable = true;
        buttonText.alpha = 1f;
    }
}
