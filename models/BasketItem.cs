namespace models;

public class BasketItem
{
    public string Sku { get; }
    public int Count { get; }
    public decimal TotalPrice { get; }

    public BasketItem(string sku, int count, decimal totalPrice)
    {
        Sku = sku;
        Count = count;
        TotalPrice = totalPrice;
    }
}

