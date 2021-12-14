namespace models;
public class Cashier
{
    private readonly ProductCatalogue productCatalogue;
    private Dictionary<string, BasketItem> _basket = new Dictionary<string, BasketItem>();

    public Cashier(ProductCatalogue productCatalogue)
    {
        this.productCatalogue = productCatalogue;
    }

    public void ScanProducts(params string[] skus)
    {
        foreach (var product in skus)
            ScanProduct(product);
    }
    public bool ScanProduct(string sku)
    {
        int skuCount = 0;

        //check if same item is already in basket
        if (_basket.ContainsKey(sku))
            skuCount = _basket[sku].Count;

        skuCount++;

        //items price based on items count
        var totalPrice = productCatalogue.GetTotalPrice(sku, skuCount);

        //update basket
        _basket[sku] = new BasketItem(sku, skuCount, totalPrice);

        return (totalPrice != 0);
    }

    public decimal GetTotalPrice()
    {
        return _basket.Values.Sum(x => x.TotalPrice);
    }
}

