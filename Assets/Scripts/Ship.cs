using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    private GraphicRaycaster raycaster;

    // Invoked on placement
    public event Action OnShipPlaced;
    // Invoked on removal
    public event Action OnShipRemoved;
    // Invoked if destroyed before first placement
    public event Action OnShipCancelled;

    // Cell representation of the ship
    public List<Image> ShipCells { get; private set; }
    // Cells occupied by the ship
    public BoardCell[] OccupiedCells { get; set; }
    public int Size => ShipCells.Count;

    private void Awake()
    {
        raycaster = GetComponentInParent<GraphicRaycaster>();
        SetOccupiedCells(new BoardCell[0]);
        ShipCells = new(GetComponentsInChildren<Image>());
        // Remove the image of the ship
        ShipCells.RemoveAt(ShipCells.Count - 1);
        Debug.Log($"{gameObject.name} awake. Ship Cells: {ShipCells.Count}, Size: {Size}");
    }

    private void OnDestroy()
    {
        if (OccupiedCells.Length == 0)
        {
            OnShipCancelled?.Invoke();
        }
        else
        {
            SetOccupiedCells(new BoardCell[0]);
        }
    }

    public void DisableRaycastTargets()
    {
        foreach (Image cell in ShipCells)
        {
            cell.raycastTarget = false;
        }
    }

    public void EnableRaycastTargets()
    {
        foreach (Image cell in ShipCells)
        {
            cell.raycastTarget = true;
        }
    }

    public void SetOccupiedCells(BoardCell[] cells)
    {
        if (OccupiedCells != null)
        {
            foreach (BoardCell cell in OccupiedCells)
            {
                if (cell != null)
                {
                    cell.Occupant = null;
                    Debug.Log($"{cell.name} no longer occupied");
                }
            }
            if (OccupiedCells.Length > 0) OnShipRemoved?.Invoke();
        }
        OccupiedCells = cells;
        if (cells.Length > 0)
        {
            foreach (BoardCell cell in OccupiedCells)
            {
                cell.Occupant = this;
                Debug.Log($"{cell.name} occupied");
            }
            OnShipPlaced?.Invoke();
        }
    }

    // Raycast from each cell of the ship
    public List<RaycastResult> Raycast()
    {
        List<RaycastResult> results = new();
        foreach (Image shipCell in ShipCells)
        {
            PointerEventData pointerEventData = new(EventSystem.current)
            {
                position = shipCell.transform.position
            };
            raycaster.Raycast(pointerEventData, results);
        }
        return results;
    }
}
