using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Image[] shipImages;
    private InputActions input;

    private void Awake() {
        input = new InputActions();
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
        shipImages = transform.GetComponentsInChildren<Image>();
        foreach (Image image in shipImages) {
            image.raycastTarget = false;
        }
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
            foreach (Image image in shipImages) {
                image.raycastTarget = true;
            }
        }
    }
}
