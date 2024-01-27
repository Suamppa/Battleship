using UnityEngine;

public class ManageStartButton : MonoBehaviour
{
    public GameObject startButton;

    private void Start()
    {
        startButton.SetActive(false);
    }

    private void OnEnable()
    {
        startButton.SetActive(true);
    }

    private void OnDisable()
    {
        startButton.SetActive(false);
    }
}
