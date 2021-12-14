namespace models;
public class Cashier
{
    List<Product> _products = new List<Product>();
    private readonly ProductCatalogue productCatalogue;

    public Cashier(ProductCatalogue productCatalogue)
    {
        this.productCatalogue = productCatalogue;
    }
    public bool ScanProduct(string sku)
    {
        _products.Add(new Product() { Sku = sku} );
        return true;
    }

    public decimal GetTotalPrice()
    {
        return _products.Sum(x=> x.Price);
    }
}

public class Product
{
    public string Sku { get; set; }
    public decimal Price { get; set; }
}

public class ProductCatalogue
{
    Dictionary<string, Product> _products = new Dictionary<string, Product>();
    Dictionary<string, IPricingStrategy> _prices = new Dictionary<string, IPricingStrategy>();
    public Product GetProduct(string sku)
    {
        var prod = _products[sku];
        prod.Price = _prices[sku].GetPrice(1);
        return prod;
    }
}

public interface IPricingStrategy
{
    string Sku { get; }
    int ProductsTresholdCount { get; }
    decimal GetPrice(int count);

}

public class BasePricingStrategy : IPricingStrategy
{
    public string Sku { get; }
    public int ProductsTresholdCount { get; }
    public decimal Price { get; }

    public BasePricingStrategy(string sku, int tresholdCount, decimal price)
    {
        Sku = sku;
        ProductsTresholdCount = tresholdCount;
        Price = price;
    }

    public decimal GetPrice(int count)
    {
        if (count >= ProductsTresholdCount)
            return Price;
        else
            return 0m;
    }
}

