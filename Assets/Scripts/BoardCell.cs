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

    private void AlignToCell(GameObject gameObject, PointerEventData eventData) {
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        Vector2 pointerOffset = (Vector2) rectTransform.position - eventData.position;

        Transform nearestCell = null;
        float minDistance = float.MaxValue;
        foreach (Transform child in transform) {
            float distance = Vector2.Distance(child.position, eventData.position);
            if (child.CompareTag("Ship") && distance < minDistance) {
                minDistance = distance;
                nearestCell = child;
            }
        }

        Vector2 cellOffset = nearestCell.position - rectTransform.position;
        Vector2 finalOffset = pointerOffset - cellOffset;

        rectTransform.position += (Vector3) finalOffset;
    }
}
