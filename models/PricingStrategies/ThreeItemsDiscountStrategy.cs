namespace models;

public class ThreeItemsDiscountStrategy : BasePricingStrategy
{
    public ThreeItemsDiscountStrategy(string sku, decimal price) : base(sku, 3, price)
    {
    }
}

