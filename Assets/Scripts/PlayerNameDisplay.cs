using TMPro;
using UnityEngine;

public class PlayerNameDisplay : MonoBehaviour
{
    private TMP_Text playerNameText;

    public int playerNumber = 1;

    private void Awake()
    {
        playerNameText = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        GameOptionsProvider.OnGameOptionsUpdated += UpdatePlayerName;
        UpdatePlayerName();
    }

    private void OnDestroy()
    {
        GameOptionsProvider.OnGameOptionsUpdated -= UpdatePlayerName;
    }

    private void UpdatePlayerName()
    {
        playerNameText.text = playerNumber == 1 ? GameOptionsProvider.PlayerOneName : GameOptionsProvider.PlayerTwoName;
    }
}
