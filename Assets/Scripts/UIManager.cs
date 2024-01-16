using UnityEngine;

// Class for controlling the UI flow within a scene
public class UIManager : MonoBehaviour
{
    private int currentPanelIndex = 0;

    // public delegate void PanelSwitchedEventHandler();
    // public event PanelSwitchedEventHandler PanelSwitched;

    // Singleton instance
    public static UIManager Instance { get; private set; }
    
    public GameObject[] panels;

    private void Awake() {
        // If the singleton hasn't been initialized yet
        if (Instance == null) {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        foreach (GameObject panel in panels) {
            panel.SetActive(false);
        }
        panels[currentPanelIndex].SetActive(true);
    }

    public void NextPanel() {
        panels[currentPanelIndex].SetActive(false);
        currentPanelIndex++;
        panels[currentPanelIndex].SetActive(true);
        // PanelSwitched?.Invoke();
    }

    public void PreviousPanel() {
        panels[currentPanelIndex].SetActive(false);
        currentPanelIndex--;
        panels[currentPanelIndex].SetActive(true);
        // PanelSwitched?.Invoke();
    }
}
