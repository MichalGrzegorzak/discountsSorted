namespace models;

public class RegularStrategy : BasePricingStrategy
{
    public RegularStrategy(string sku, decimal price) : base(sku, 1, price)
    {
    }
}

