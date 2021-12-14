namespace models;
public class Cashier
{
    List<BasketItem> _basket = new List<BasketItem>();
    private readonly ProductCatalogue productCatalogue;

    public Cashier(ProductCatalogue productCatalogue)
    {
        this.productCatalogue = productCatalogue;
    }
    public bool ScanProduct(string sku)
    {
        var cnt = _basket.Count(x => x.Sku == sku);
        var total = productCatalogue.GetTotalPrice(sku, cnt);
        _basket.Add(new BasketItem(sku, cnt, total));
        return true;
    }

    public decimal GetTotalPrice()
    {
        return _basket.Sum(x=> x.TotalPrice);
    }
}

