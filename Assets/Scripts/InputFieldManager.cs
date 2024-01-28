using TMPro;
using UnityEngine;

// Rather specific class for handling player name input for two players
public class InputFieldManager : MonoBehaviour
{
    private TMP_InputField[] inputFields;

    public ToggleClickable button;

    private void Awake()
    {
        inputFields = GetComponentsInChildren<TMP_InputField>();
    }

    private void OnEnable()
    {
        foreach (TMP_InputField inputField in inputFields)
        {
            inputField.onValueChanged.AddListener(OnInputFieldValueChanged);
        }
    }

    private void OnDisable()
    {
        foreach (TMP_InputField inputField in inputFields)
        {
            inputField.onValueChanged.RemoveListener(OnInputFieldValueChanged);
        }
    }

    private void OnInputFieldValueChanged(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            button.Disable();
        }
        else
        {
            button.Enable();
        }
    }

    public void UpdatePlayerNames()
    {
        GameOptionsProvider.PlayerOneName = inputFields[0].text;
        GameOptionsProvider.PlayerTwoName = inputFields[1].text;
        Debug.Log($"Player names updated: {GameOptionsProvider.PlayerOneName}, {GameOptionsProvider.PlayerTwoName}");
    }
}
