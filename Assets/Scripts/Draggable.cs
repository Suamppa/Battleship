using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(Ship))]
public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Ship ship;
    private InputActions input;
    private GraphicRaycaster raycaster;

    // public static event Action ShipMoved;

    private void Awake() {
        ship = GetComponent<Ship>();
        input = new InputActions();
        raycaster = GetComponentInParent<GraphicRaycaster>();
    }

    private void OnPointerRotate(InputAction.CallbackContext context) {
        transform.Rotate(0, 0, context.ReadValue<Vector2>().normalized.y * 90);
    }

    private void OnRotateCCW(InputAction.CallbackContext context) {
        transform.Rotate(0, 0, 90);
    }

    private void OnRotateCW(InputAction.CallbackContext context) {
        transform.Rotate(0, 0, -90);
    }

    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log($"{gameObject.name} OnBeginDrag");
        input.Enable();
        input.Setup.PointerRotate.performed += OnPointerRotate;
        input.Setup.RotateCCW.performed += OnRotateCCW;
        input.Setup.RotateCW.performed += OnRotateCW;

        if (transform.parent.gameObject.layer == LayerMask.NameToLayer("Board")) {
            transform.SetParent(transform.root);
        }
        transform.transform.SetAsLastSibling();
        ship.DisableRaycastTargets();
    }

    public void OnDrag(PointerEventData eventData) {
        transform.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData) {
        input.Setup.PointerRotate.performed -= OnPointerRotate;
        input.Setup.RotateCCW.performed -= OnRotateCCW;
        input.Setup.RotateCW.performed -= OnRotateCW;
        input.Disable();

        GameObject objectBelow = eventData.pointerCurrentRaycast.gameObject;
        if (objectBelow == null || objectBelow.layer != LayerMask.NameToLayer("Board")) {
            Destroy(gameObject);
        } else if (eventData.pointerDrag != null) {
            OccupyCells();
            if (ship != null) ship.EnableRaycastTargets();
        }
        // ShipMoved?.Invoke();
    }

    private void OccupyCells() {
        List<RaycastResult> results = new();
        List<BoardCell> cells = new();
        foreach (Image cell in ship.ShipCells) {
            PointerEventData pointerEventData = new(EventSystem.current) {
                position = cell.transform.position
            };
            raycaster.Raycast(pointerEventData, results);
        }

        foreach (RaycastResult result in results) {
            if (result.gameObject.TryGetComponent(out BoardCell cell)) {
                if (cell.IsOccupied) {
                    Destroy(gameObject);
                    return;
                }
                cells.Add(cell);
            }
        }
        ship.SetOccupiedCells(cells.ToArray());
    }
}
