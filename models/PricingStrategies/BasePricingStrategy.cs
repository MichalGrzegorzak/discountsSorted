namespace models;

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

