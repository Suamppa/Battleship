using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Class representing a cell on the game board
public class BoardCell : MonoBehaviour, IDropHandler
{
    // private GraphicRaycaster raycaster;

    public bool IsOccupied { get; set; } = false;

    // private void Awake() {
    //     raycaster = GetComponentInParent<GraphicRaycaster>();
    // }

    // private void OnEnable() {
    //     Draggable.ShipMoved += CheckForShip;
    // }

    // private void OnDisable() {
    //     Draggable.ShipMoved -= CheckForShip;
    // }

    public void OnDrop(PointerEventData eventData) {
        GameObject droppedObject = eventData.pointerDrag;
        if (droppedObject == null) return;
        if (!IsOccupied) {
            droppedObject.transform.SetParent(transform);
            droppedObject.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        } else {
            Destroy(droppedObject);
        }
    }

    // public void CheckForShip() {
    //     PointerEventData pointerEventData = new(EventSystem.current) {
    //         position = transform.position
    //     };
    //     List<RaycastResult> results = new();
    //     raycaster.Raycast(pointerEventData, results);

    //     IsOccupied = false;
    //     foreach (RaycastResult result in results) {
    //         if (result.gameObject.CompareTag("Ship")) {
    //             IsOccupied = true;
    //             Debug.Log($"{gameObject.name} occupied");
    //             break;
    //         }
    //     }
    // }
}
