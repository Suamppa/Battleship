using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private void Awake()
    {
        if (transform.parent == null)
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
