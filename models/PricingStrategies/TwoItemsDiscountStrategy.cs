namespace models;

public class TwoItemsDiscountStrategy : BasePricingStrategy
{
    public TwoItemsDiscountStrategy(string sku, decimal price) : base(sku, 2, price)
    {
    }
}

