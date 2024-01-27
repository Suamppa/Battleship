using UnityEngine;
using UnityEngine.EventSystems;

public class ShipSpawner : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private QuantityText quantityText;

    public GameObject ShipPrefab;

    private void Awake()
    {
        quantityText = GetComponentInChildren<QuantityText>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log($"{gameObject.name} OnBeginDrag");
        if (ShipPrefab != null)
        {
            // Instantiate the prefab at the current mouse position
            GameObject instance = Instantiate(ShipPrefab, transform.root);
            Debug.Log($"{instance.name} instantiated");
            eventData.pointerDrag = instance;

            if (instance.TryGetComponent(out Ship ship))
            {
                ship.OnShipPlaced += quantityText.IncreaseQuantity;
                ship.OnShipRemoved += quantityText.DecreaseQuantity;
            }

            // Now trigger the OnBeginDrag event on the Draggable component of the new instance
            ExecuteEvents.Execute<IBeginDragHandler>(instance, eventData, (x, y) => x.OnBeginDrag((PointerEventData)y));
        }
    }

    // These need to be impelemented for OnBeginDrag to work
    public void OnDrag(PointerEventData eventData)
    {
        return;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        return;
    }
}
