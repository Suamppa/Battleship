using System.Collections.Generic;
using UnityEngine;

// Class representing the game board
[RequireComponent(typeof(RectTransform))]
public class GameBoard : MonoBehaviour
{
    private RectTransform rectTransform;

    public List<BoardCell> Cells { get; private set; }
    public int Height => GameOptionsProvider.Instance.BoardHeight;
    public int Width => GameOptionsProvider.Instance.BoardWidth;

    public GameObject cellPrefab;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        Cells = new(GetComponentsInChildren<BoardCell>());
    }

    private void OnEnable() {
        ResizeBoard();
    }

    // Fills the board with cells
    private void FillBoardWithCells() {
        int targetBoardSize = Height * Width;
        int cellCount = Cells.Count;
        if (cellCount < targetBoardSize) {
            for (int i = cellCount; i < targetBoardSize; i++) {
                Cells.Add(Instantiate(cellPrefab, rectTransform).GetComponent<BoardCell>());
            }
        }
        else if (cellCount > targetBoardSize) {
            for (int i = targetBoardSize; i < cellCount; i++) {
                Destroy(Cells[i].gameObject);
            }
            Cells.RemoveRange(targetBoardSize, cellCount - targetBoardSize);
        }
    }

    private void ResizeBoard() {
        // Get the size of the board
        Vector2 boardSize = rectTransform.sizeDelta;

        // Get the size of the cell
        Vector2 cellSize = cellPrefab.GetComponent<RectTransform>().sizeDelta;

        boardSize.x = cellSize.x * Width;
        boardSize.y = cellSize.y * Height;

        rectTransform.sizeDelta = boardSize;

        FillBoardWithCells();
    }
}
