using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class StartButton : MonoBehaviour
{
    [SerializeField]
    private GameObject[] fromElement, toElement;
    private Button button;

    private void Awake() {
        button = GetComponent<Button>();
    }

    private void Start() {
        // If fromElement is not specified, use the parent of the button
        if (fromElement == null || fromElement.Length == 0) {
            fromElement = new GameObject[] { transform.parent.gameObject };
        }
        if (toElement != null && toElement.Length > 0) {
            // Other listeners are set in the inspector
            button.onClick.AddListener(() => {
                UIManager.Instance.SwitchElements(fromElement, toElement);
            });
        }
    }

    private void OnDestroy() {
        button.onClick.RemoveAllListeners();
    }
}
