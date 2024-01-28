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

    public Color shipAvailableColor = Color.white;
    public Color shipUnavailableColor = Color.red;

    private void Awake()
    {
        textComponent = GetComponent<TMP_Text>();
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

    public void SetAvailability(bool available)
    {
        textComponent.color = available ? shipAvailableColor : shipUnavailableColor;
    }
}
