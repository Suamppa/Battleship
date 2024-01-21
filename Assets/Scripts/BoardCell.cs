using UnityEngine;
using UnityEngine.EventSystems;

// Class representing a cell on the game board
public class BoardCell : MonoBehaviour, IDropHandler
{
    public bool IsOccupied { get; set; } = false;

    public void OnDrop(PointerEventData eventData) {
        GameObject droppedObject = eventData.pointerDrag;
        if (droppedObject == null) return;
        if (!IsOccupied) {
            droppedObject.transform.SetParent(transform);
            droppedObject.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            IsOccupied = true;
            Debug.Log($"{gameObject.name} occupied");
        } else {
            Destroy(droppedObject);
        }
    }
}
