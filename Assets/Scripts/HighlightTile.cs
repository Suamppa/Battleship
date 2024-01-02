using UnityEngine;

public class HighlightTile : MonoBehaviour
{
    // Object to use as a highlight
    public GameObject highlight;

    void OnMouseEnter() {
        highlight.SetActive(true);
    }

    void OnMouseExit()
    {
        highlight.SetActive(false);
    }
}
