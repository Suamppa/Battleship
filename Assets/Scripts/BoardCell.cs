using UnityEngine;

// Class representing a cell on the game board
public class BoardCell : MonoBehaviour
{
    [HideInInspector]
    public bool IsOccupied { get; set; } = false;
}
