using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    public List<Image> ShipCells { get; private set; }
    public BoardCell[] OccupiedCells { get; set; }

    private void Awake() {
        ShipCells = new(GetComponentsInChildren<Image>());
        // Remove the image of the ship
        ShipCells.RemoveAt(ShipCells.Count - 1);
        OccupiedCells = new BoardCell[0];
    }

    private void OnDestroy() {
        SetOccupiedCells(new BoardCell[0]);
    }

    public void DisableRaycastTargets() {
        foreach (Image cell in ShipCells) {
            cell.raycastTarget = false;
        }
    }

    public void EnableRaycastTargets() {
        foreach (Image cell in ShipCells) {
            cell.raycastTarget = true;
        }
    }

    public void SetOccupiedCells(BoardCell[] cells) {
        foreach (BoardCell cell in OccupiedCells) {
            cell.IsOccupied = false;
            Debug.Log($"{cell.name} no longer occupied");
        }
        OccupiedCells = cells;
        foreach (BoardCell cell in OccupiedCells) {
            cell.IsOccupied = true;
            Debug.Log($"{cell.name} occupied");
        }
    }
}
