using System.Collections.Generic;
using UnityEngine;

// Class representing the game board
[RequireComponent(typeof(RectTransform))]
public class GameBoard : MonoBehaviour
{
    private RectTransform gridTransform;
    // Separate ship layer prevents cell outlines clipping over ships
    private RectTransform shipLayerTransform;
    private GameObject shipLayerCell;

    public List<BoardCell> Cells { get; private set; }
    public int Height => GameOptionsProvider.BoardHeight;
    public int Width => GameOptionsProvider.BoardWidth;

    public GameObject cellPrefab;

    private void Awake()
    {
        gridTransform = transform.GetChild(0).GetComponent<RectTransform>();
        shipLayerTransform = transform.GetChild(1).GetComponent<RectTransform>();
        shipLayerCell = shipLayerTransform.GetChild(0).gameObject;
        Cells = new(gridTransform.GetComponentsInChildren<BoardCell>());
    }

    private void OnEnable()
    {
        ResizeBoard();
    }

    // Fills the board with cells
    private void FillBoardWithCells()
    {
        int targetBoardSize = Height * Width;
        int cellCount = Cells.Count;
        if (cellCount < targetBoardSize)
        {
            for (int i = cellCount; i < targetBoardSize; i++)
            {
                Cells.Add(Instantiate(cellPrefab, gridTransform).GetComponent<BoardCell>());
                Instantiate(shipLayerCell, shipLayerTransform);
            }
        }
        else if (cellCount > targetBoardSize)
        {
            for (int i = targetBoardSize; i < cellCount; i++)
            {
                Destroy(Cells[i].gameObject);
                Destroy(shipLayerTransform.GetChild(i).gameObject);
            }
            Cells.RemoveRange(targetBoardSize, cellCount - targetBoardSize);
        }
    }

    private void ResizeBoard()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
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
