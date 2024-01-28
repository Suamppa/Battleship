using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShipSpawner : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private static readonly List<ShipSpawner> spawners = new();
    private static SpaceDisplay spaceDisplay;

    private GameObject shipToSpawn;
    private List<GameObject> spawnedShips;
    private QuantityText quantityText;

    public bool SpawnerEnabled { get; set; }

    public GameObject shipPrefab;

    private void Awake()
    {
        spawners.Add(this);
        spawnedShips = new List<GameObject>();
        quantityText = GetComponentInChildren<QuantityText>();

        // Ship prefab needs to be instantiated to wake up the Ship component
        shipToSpawn = Instantiate(shipPrefab, transform);
        foreach (Graphic graphic in shipToSpawn.GetComponentsInChildren<Graphic>())
        {
            graphic.enabled = false;
        }
    }

    private void OnDestroy()
    {
        spawners.Remove(this);
    }

    private void OnEnable()
    {
        spaceDisplay = GameObject.FindWithTag("SpaceDisplay").GetComponent<SpaceDisplay>();
        Debug.Log($"Space display set to {spaceDisplay.gameObject.name}");

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
                shipComponent.OnShipPlaced += CheckAvailableSpaceForAll;
                shipComponent.OnShipRemoved += quantityText.DecreaseQuantity;
                shipComponent.OnShipRemoved += CheckAvailableSpaceForAll;
            }
        }
        foreach (GameObject ship in shipsToRemove)
        {
            spawnedShips.Remove(ship);
        }
        if (spawnedShips.Count > 0)
        {
            CheckAvailableSpace();
        }
        else
        {
            EnableSpawner();
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
                shipComponent.OnShipPlaced -= CheckAvailableSpaceForAll;
                shipComponent.OnShipRemoved -= quantityText.DecreaseQuantity;
                shipComponent.OnShipRemoved -= CheckAvailableSpaceForAll;
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
        if (shipPrefab != null)
        {
            // Instantiate the prefab at the current mouse position
            GameObject instance = Instantiate(shipPrefab, transform.root);
            instance.name = $"{shipPrefab.name} {spawnedShips.Count}";
            Debug.Log($"{instance.name} instantiated");
            eventData.pointerDrag = instance;
            spawnedShips.Add(instance);

            if (instance.TryGetComponent(out Ship ship))
            {
                ship.OnShipPlaced += quantityText.IncreaseQuantity;
                ship.OnShipPlaced += CheckAvailableSpaceForAll;
                ship.OnShipRemoved += quantityText.DecreaseQuantity;
                ship.OnShipRemoved += CheckAvailableSpaceForAll;
                ship.OnShipCancelled += () => spawnedShips.Remove(instance);
            }
            else
            {
                Debug.LogError($"{instance.name} does not have a Ship component");
            }

            // Now trigger the OnBeginDrag event on the Draggable component of the new instance
            ExecuteEvents.Execute<IBeginDragHandler>(instance, eventData, (x, y) => x.OnBeginDrag((PointerEventData)y));
        }
    }

    public static void CheckAvailableSpaceForAll()
    {
        foreach (ShipSpawner spawner in spawners)
        {
            spawner.CheckAvailableSpace();
        }
    }

    private void CheckAvailableSpace()
    {
        int spaceRequired = shipToSpawn.GetComponent<Ship>().Size;
        int spaceLeft = GameOptionsProvider.MaxShipArea - GameBoard.ActiveBoard.CellsOccupied;
        bool canSpawn = spaceLeft >= spaceRequired;
        Debug.Log($"{gameObject.name} can spawn: {canSpawn} ({spaceLeft} / {spaceRequired})");
        spaceDisplay.UpdateSpaceDisplay();

        if (canSpawn && !SpawnerEnabled)
        {
            EnableSpawner();
        }
        else if (!canSpawn && SpawnerEnabled)
        {
            DisableSpawner();
        }
    }

    public void DisableSpawner()
    {
        foreach (Image image in GetComponentsInChildren<Image>())
        {
            image.raycastTarget = false;
            Color color = image.color;
            color.a *= 0.5f;
            image.color = color;
        }
        quantityText.SetAvailability(false);
        SpawnerEnabled = false;
        Debug.Log($"{gameObject.name} disabled");
    }

    public void EnableSpawner()
    {
        foreach (Image image in GetComponentsInChildren<Image>())
        {
            image.raycastTarget = true;
            Color color = image.color;
            color.a /= 0.5f;
            image.color = color;
        }
        quantityText.SetAvailability(true);
        SpawnerEnabled = true;
        Debug.Log($"{gameObject.name} enabled");
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
