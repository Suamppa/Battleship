using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class QuantityText : MonoBehaviour
{
    private TMP_Text textComponent;
    private int quantity;

    public string Text { get => textComponent.text; private set => textComponent.text = value; }
    public int Quantity
    {
        get { return quantity; }
        set
        {
            quantity = value;
            Text = quantity.ToString();
        }
    }

    private void Awake()
    {
        if (!TryGetComponent(out textComponent))
        {
            Debug.LogError("No quantity text found");
        }
        Quantity = 0;
    }

    public void IncreaseQuantity()
    {
        Quantity++;
    }

    public void DecreaseQuantity()
    {
        Quantity--;
    }
}
