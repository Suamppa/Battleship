using UnityEngine;

public class ReadyButton : MonoBehaviour
{
    private ToggleClickable toggleClickable;

    private void Awake()
    {
        toggleClickable = GetComponent<ToggleClickable>();
    }

    private void OnEnable()
    {
        GameBoard.ActiveBoard.OnBoardStateChanged += CheckReadyState;
    }

    private void OnDisable()
    {
        GameBoard.ActiveBoard.OnBoardStateChanged -= CheckReadyState;
    }

    private void CheckReadyState()
    {
        if (GameBoard.ActiveBoard.CellsOccupied > 0)
        {
            toggleClickable.Enable();
        }
        else
        {
            toggleClickable.Disable();
        }
    }
}
