using System.Collections.Generic;
using UnityEngine;

// Class representing the game board
[RequireComponent(typeof(RectTransform))]
public class GameBoard : MonoBehaviour
{
    private RectTransform gridTransform;
    // Separate ship layer prevents cell outlines clipping over ships
    private RectTransform shipLayerTransform;
    // GameObject used to instantiate ship layer cells
    private GameObject shipLayerCell;

    public static GameBoard ActiveBoard { get; private set; }

    public List<BoardCell> Cells { get; private set; }
    public int CellsOccupied { get; set; } = 0;
    public int Height => GameOptionsProvider.BoardHeight;
    public int Width => GameOptionsProvider.BoardWidth;

    public GameObject cellPrefab;

    private void Awake()
    {
        gridTransform = transform.GetChild(0).GetComponent<RectTransform>();
        shipLayerTransform = transform.GetChild(1).GetComponent<RectTransform>();
        Cells = new(gridTransform.GetComponentsInChildren<BoardCell>());

        shipLayerCell = new("Cell", typeof(RectTransform));
        RectTransform shipLayerCellTransform = shipLayerCell.GetComponent<RectTransform>();
        RectTransform cellPrefabTransform = cellPrefab.GetComponent<RectTransform>();

        // Copy RectTransform values from cellPrefab to shipLayerCell
        shipLayerCellTransform.sizeDelta = cellPrefabTransform.sizeDelta;
        shipLayerCellTransform.anchorMin = cellPrefabTransform.anchorMin;
        shipLayerCellTransform.anchorMax = cellPrefabTransform.anchorMax;
        shipLayerCellTransform.pivot = cellPrefabTransform.pivot;
        shipLayerCellTransform.anchoredPosition = cellPrefabTransform.anchoredPosition;
        shipLayerCellTransform.offsetMin = cellPrefabTransform.offsetMin;
        shipLayerCellTransform.offsetMax = cellPrefabTransform.offsetMax;
    }

    private void OnEnable()
    {
        MakeActiveBoard();
        ResizeBoard();
    }

    public void MakeActiveBoard()
    {
        ActiveBoard = this;
    }

    // Fills the board with cells
    private void FillBoardWithCells()
    {
        if (Cells.Count > 0) ClearBoardOfCells();

        int targetBoardSize = Height * Width;
        for (int i = 0; i < targetBoardSize; i++)
        {
            Instantiate(shipLayerCell, shipLayerTransform).name = $"Cell {i}";
            GameObject gridCell = Instantiate(cellPrefab, gridTransform);
            gridCell.name = $"Cell {i}";
            Cells.Add(gridCell.GetComponent<BoardCell>());
        }
    }

    private void ResizeBoard()
    {
        ClearBoardOfCells();

        RectTransform rectTransform = GetComponent<RectTransform>();
        // Get the size of the board
        Vector2 boardSize = rectTransform.sizeDelta;

        // Get the size of the cell
        Vector2 cellSize = cellPrefab.GetComponent<RectTransform>().sizeDelta;

        boardSize.x = cellSize.x * Width;
        boardSize.y = cellSize.y * Height;

        // Set the size of the board container
        rectTransform.sizeDelta = boardSize;

        FillBoardWithCells();
    }

    // Clears the board of cells and ships completely
    private void ClearBoardOfCells()
    {
        foreach (BoardCell cell in Cells)
        {
            if (cell.Occupant != null)
            {
                Destroy(cell.Occupant.gameObject);
            }
            Destroy(cell.gameObject);
        }
        Cells.Clear();
    }
}
