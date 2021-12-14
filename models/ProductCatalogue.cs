namespace models;

public class ProductCatalogue
{
    public ILookup<string, IPricingStrategy> Pricings { get; protected set; }

    public ProductCatalogue(IPricingStrategy[] strategies)
    {
        Pricings = strategies.ToLookup(x => x.Sku, x => x);
    }

    public decimal GetTotalPrice(string sku, int skuCount)
    {
        decimal price = 0m, totalPrice = 0m;

        //get pricings, ordered by highest discount 
        var pricings = Pricings[sku].OrderByDescending(x => x.ProductsTresholdCount).ToList();

        foreach (var pricingStrategy in pricings)
        {
            price = pricingStrategy.GetPrice(skuCount);

            if (pricingStrategy is BasePricingStrategy)
            {
                totalPrice += price * skuCount;
                skuCount = 0;
            }
            else if (skuCount >= pricingStrategy.ProductsTresholdCount)
            {
                totalPrice += price * pricingStrategy.ProductsTresholdCount;
                skuCount = skuCount - pricingStrategy.ProductsTresholdCount;
            }
        }
        return totalPrice;
    }

}

