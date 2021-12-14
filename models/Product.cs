namespace models;

public class Product
{
    public string Sku { get; set; }
    public decimal Price { get; set; }
}

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

