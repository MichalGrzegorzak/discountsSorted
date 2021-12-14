namespace models;

public class ProductCatalogue
{
    private ILookup<string, IPricingStrategy> Pricings { get; }

    public ProductCatalogue(IPricingStrategy[] strategies)
    {
        Pricings = strategies.ToLookup(x => x.Sku, x => x);
    }

    public decimal GetTotalPrice(string sku, int skuCount)
    {
        decimal price = 0m, totalPrice = 0m;

        //get pricings, ordered by highest discount 
        var pricings = Pricings[sku].OrderByDescending(x => x.ProductsTresholdCount).ToList();

        while (skuCount > 0)
        {
            foreach (var pricingStrategy in pricings)
            {
                price = pricingStrategy.GetPrice(skuCount);

                if (pricingStrategy is RegularStrategy) //=> no more discounts to check
                {
                    totalPrice += price * skuCount;
                    skuCount = 0;
                }
                else if (skuCount >= pricingStrategy.ProductsTresholdCount)
                {
                    totalPrice += price * pricingStrategy.ProductsTresholdCount;
                    skuCount = skuCount - pricingStrategy.ProductsTresholdCount;
                    break; //we need to re-start discount checking
                }
            }
        }
        return totalPrice;
    }

}

