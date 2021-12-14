using models;
using Xunit;

namespace unitTests;

public class UnitTest1
{
    IPricingStrategy[] GetStrategiesABC()
    {
        return new IPricingStrategy[] {
                new BasePricingStrategy("A", 1, 1m),
                new BasePricingStrategy("B", 1, 2m),
                new BasePricingStrategy("C", 1, 5m),
                new TwoItemsDiscountStrategy("A", 0.8m),
                new TwoItemsDiscountStrategy("B", 1.5m),
                new ThreeItemsDiscountStrategy("B", 1m)
            };
    }

    [Fact]
    public void Test_Single_Product()
    {
        Cashier cashier = new Cashier(new ProductCatalogue(GetStrategiesABC()));
        cashier.ScanProduct("A");
        var result = cashier.GetTotalPrice();
        Assert.Equal(1m, result);
    }

    [Fact]
    public void Test_Double_Items_Discount()
    {
        Cashier cashier = new Cashier(new ProductCatalogue(GetStrategiesABC()));
        cashier.ScanProduct("A");
        cashier.ScanProduct("A");
        var result = cashier.GetTotalPrice();
        Assert.Equal(1.6m, result);
    }
}