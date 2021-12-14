namespace models;
public class Cashier
{
    private readonly ProductCatalogue productCatalogue;
    private Dictionary<string, BasketItem> _basket = new Dictionary<string, BasketItem>();

    public Cashier(ProductCatalogue productCatalogue)
    {
        this.productCatalogue = productCatalogue;
    }
    public bool ScanProduct(string sku)
    {
        int skuCount = 0;
        if (_basket.ContainsKey(sku))
            skuCount = _basket[sku].Count;

        skuCount++;

        var totalPrice = productCatalogue.GetTotalPrice(sku, skuCount);

        _basket[sku] = new BasketItem(sku, skuCount, totalPrice);

        return (totalPrice != 0);
    }

    public decimal GetTotalPrice()
    {
        return _basket.Values.Sum(x => x.TotalPrice);
    }
}

