using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// Class for controlling the UI flow within a scene
public class UIManager : MonoBehaviour
{
    // public delegate void PanelSwitchedEventHandler();
    // public event PanelSwitchedEventHandler PanelSwitched;

    // History of screens visited, item at the top is the current screen
    private static Stack<List<GameObject>> history;

    // Singleton instance
    public static UIManager Instance { get; private set; }
    public static List<GameObject> ActiveElements { get; private set; }

    // Elements to activate on start
    public GameObject[] initialElements;
    public GameObject battleUI;

    private void Awake()
    {
        // If the singleton hasn't been initialized yet
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        ActiveElements = new();
        history = new();
    }

    private void Start()
    {
        // Disable all children, then enable the initial elements
        foreach (Transform child in transform)
        {
            if (!child.CompareTag("Persistent") && child.gameObject.activeSelf)
            {
                child.gameObject.SetActive(false);
            }
        }
        ActivateElements(initialElements);
    }

    public static void ActivateElement(GameObject element)
    {
        if (element.layer == LayerMask.NameToLayer("UI") && !ActiveElements.Contains(element))
        {
            element.SetActive(true);
            ActiveElements.Add(element);
            history.Push(new List<GameObject> { element });
        }
        else
        {
            Debug.LogError($"Screen {element.name} is not on the UI layer.");
        }
    }

    public static void ActivateElements(GameObject[] elements)
    {
        foreach (GameObject element in elements)
        {
            if (element.layer == LayerMask.NameToLayer("UI") && !ActiveElements.Contains(element))
            {
                element.SetActive(true);
                ActiveElements.Add(element);
            }
            else
            {
                Debug.LogError($"Screen {element.name} is not on the UI layer.");
            }
        }
        history.Push(new List<GameObject>(elements));
    }

    public static void DeactivateElement(GameObject element)
    {
        if (ActiveElements.Contains(element))
        {
            element.SetActive(false);
            ActiveElements.Remove(element);
        }
        else
        {
            Debug.LogError($"Screen {element.name} is not active.");
        }
    }

    public static void DeactivateElements(GameObject[] elements)
    {
        foreach (GameObject element in elements)
        {
            DeactivateElement(element);
        }
    }

    // Switches to the specified element, closing fromElement
    public static void SwitchToElement(GameObject fromElement, GameObject toElement)
    {
        DeactivateElement(fromElement);
        ActivateElement(toElement);
    }

    public static void SwitchElements(GameObject[] fromElements, GameObject[] toElements)
    {
        DeactivateElements(fromElements);
        ActivateElements(toElements);
    }

    // Switches to the previous element in the history
    public static void GoBack()
    {
        if (history.Count > 1)
        {
            List<GameObject> fromElements = history.Pop();
            List<GameObject> toElements = history.Peek();
            Debug.Log($"Going back from {fromElements[0].name} to {toElements[0].name}");
            SwitchElements(fromElements.ToArray(), toElements.ToArray());
            // Avoid history loop, because ActivateElements pushes to history
            history.Pop();
        }
    }

    public static void QuitGame()
    {
        Application.Quit();
    }

    public void StartBattle()
    {
        // If the battle scene is already loaded, don't load it again
        if (SceneManager.GetSceneByBuildIndex(1).isLoaded) return;

        battleUI.SetActive(true);
        
        GameObject.FindWithTag("Persistent").transform.SetParent(battleUI.transform);
        foreach (GameBoard board in GameBoard.GameBoards)
        {
            board.transform.SetParent(battleUI.transform);
        }
        DontDestroyOnLoad(battleUI);

        ShowLoadingScreen();

        Debug.Log("Loading battle scene");
        SceneManager.LoadSceneAsync(1);
    }

    private void ShowLoadingScreen()
    {
        GameObject loadingScreen = transform.GetChild(transform.childCount - 1).gameObject;
        loadingScreen.SetActive(true);
    }
}
