using UnityEngine;
using UnityEngine.EventSystems;

// Class representing a cell on the game board
public class BoardCell : MonoBehaviour, IDropHandler
{
    // Equivalent cell on the ship layer of the board
    private Transform shipLayerCell;

    // public bool IsOccupied { get; set; } = false;
    public Ship Occupant { get; set; } = null;

    private void Awake()
    {
        shipLayerCell = transform.parent.parent.GetChild(1).GetChild(transform.GetSiblingIndex());
    }

    private void OnDestroy()
    {
        if (Occupant != null)
        {
            Destroy(Occupant.gameObject);
        }
    }

    // Called when a ship is dropped on the cell
    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedObject = eventData.pointerDrag;
        if (droppedObject == null) return;
        if (Occupant == null)
        {
            droppedObject.transform.SetParent(shipLayerCell);
            droppedObject.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        }
        else
        {
            Destroy(droppedObject);
        }
    }
}
