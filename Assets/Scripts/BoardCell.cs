using UnityEngine;
using UnityEngine.EventSystems;

// Class representing a cell on the game board
public class BoardCell : MonoBehaviour, IDropHandler
{
    // Equivalent cell on the ship layer of the board
    private Transform shipLayerCell;
    private Ship occupant;
    private GameBoard gameBoard;

    public Ship Occupant {
        get { return occupant; }
        set
        {
            if (value == null && occupant != null)
            {
                occupant = null;
                gameBoard.CellsOccupied--;
            }
            else if (value != null && occupant == null)
            {
                occupant = value;
                gameBoard.CellsOccupied++;
            }
            else
            {
                occupant = value;
            }
        }
    }

    private void OnEnable()
    {
        gameBoard = GetComponentInParent<GameBoard>();
        shipLayerCell = gameBoard.transform.GetChild(1).GetChild(transform.GetSiblingIndex());
    }

    private void OnDestroy()
    {
        if (Occupant != null)
        {
            Destroy(Occupant.gameObject);
        }
        if (shipLayerCell != null)
        {
            Destroy(shipLayerCell.gameObject);
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
