using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Ship))]
public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Ship ship;
    private InputActions input;
    private bool inputEnabled = false;

    private void Awake()
    {
        ship = GetComponent<Ship>();
        input = new InputActions();
    }

    private void OnPointerRotate(InputAction.CallbackContext context)
    {
        transform.Rotate(0, 0, context.ReadValue<Vector2>().normalized.y * 90);
    }

    private void OnRotateCCW(InputAction.CallbackContext context)
    {
        transform.Rotate(0, 0, 90);
    }

    private void OnRotateCW(InputAction.CallbackContext context)
    {
        transform.Rotate(0, 0, -90);
    }

    private void EnableInput()
    {
        input.Enable();
        input.Setup.PointerRotate.performed += OnPointerRotate;
        input.Setup.RotateCCW.performed += OnRotateCCW;
        input.Setup.RotateCW.performed += OnRotateCW;
        inputEnabled = true;
    }

    private void DisableInput()
    {
        input.Setup.PointerRotate.performed -= OnPointerRotate;
        input.Setup.RotateCCW.performed -= OnRotateCCW;
        input.Setup.RotateCW.performed -= OnRotateCW;
        input.Disable();
        inputEnabled = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log($"{gameObject.name} OnBeginDrag");
        EnableInput();
        ship.OnShipRemoved += DisableInput;

        if (transform.parent.gameObject.layer == LayerMask.NameToLayer("Board"))
        {
            transform.SetParent(transform.root);
        }
        transform.SetAsLastSibling();
        ship.DisableRaycastTargets();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (inputEnabled) DisableInput();

        // A speedier check to see if the pointer is over the board
        GameObject objectBelow = eventData.pointerCurrentRaycast.gameObject;
        if (objectBelow == null || objectBelow.layer != LayerMask.NameToLayer("Board"))
        {
            Destroy(gameObject);
        }
        else if (eventData.pointerDrag != null)
        {
            OccupyCells(); // This will destroy the ship if the cells are occupied
            if (ship != null) ship.EnableRaycastTargets();
        }
    }

    private void OccupyCells()
    {
        List<BoardCell> cells = new();
        List<RaycastResult> results = ship.Raycast();

        foreach (RaycastResult result in results)
        {
            if (result.gameObject.TryGetComponent(out BoardCell cell))
            {
                if (cell.Occupant != null)
                {
                    Destroy(gameObject);
                    return;
                }
                cells.Add(cell);
            }
        }
        // If the ship is too big for the drop area, destroy it
        if (cells.Count < ship.ShipCells.Count)
        {
            Destroy(gameObject);
        }
        else
        {
            ship.SetOccupiedCells(cells.ToArray());
        }
    }
}
