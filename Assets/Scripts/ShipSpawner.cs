using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShipSpawner : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private List<GameObject> spawnedShips;
    private QuantityText quantityText;

    public GameObject ShipPrefab;

    private void Awake()
    {
        spawnedShips = new List<GameObject>();
        quantityText = GetComponentInChildren<QuantityText>();
    }

    private void OnEnable()
    {
        List<GameObject> shipsToRemove = new();
        foreach (GameObject ship in spawnedShips)
        {
            if (ship == null)
            {
                shipsToRemove.Add(ship);
            }
            else if (ship.TryGetComponent(out Ship shipComponent))
            {
                shipComponent.OnShipPlaced += quantityText.IncreaseQuantity;
                shipComponent.OnShipRemoved += quantityText.DecreaseQuantity;
            }
        }
        foreach (GameObject ship in shipsToRemove)
        {
            spawnedShips.Remove(ship);
        }
    }

    private void OnDisable()
    {
        List<GameObject> shipsToRemove = new();
        foreach (GameObject ship in spawnedShips)
        {
            if (ship == null)
            {
                shipsToRemove.Add(ship);
            }
            else if (ship.TryGetComponent(out Ship shipComponent))
            {
                shipComponent.OnShipPlaced -= quantityText.IncreaseQuantity;
                shipComponent.OnShipRemoved -= quantityText.DecreaseQuantity;
            }
        }
        foreach (GameObject ship in shipsToRemove)
        {
            spawnedShips.Remove(ship);
        }
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
            spawnedShips.Add(instance);

            if (instance.TryGetComponent(out Ship ship))
            {
                ship.OnShipPlaced += quantityText.IncreaseQuantity;
                ship.OnShipRemoved += quantityText.DecreaseQuantity;
                ship.OnShipCancelled += () => spawnedShips.Remove(instance);
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
