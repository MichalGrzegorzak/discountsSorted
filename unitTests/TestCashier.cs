using models;
using Xunit;

namespace unitTests;

public class TestCashier
{
    IPricingStrategy[] GetStrategiesABC()
    {
        return new IPricingStrategy[] {
                new RegularStrategy("A", 1m),
                new RegularStrategy("B", 2m),
                new RegularStrategy("C", 5m),
                new TwoItemsDiscountStrategy("A", 0.8m),
                new TwoItemsDiscountStrategy("B", 1.5m),
                new ThreeItemsDiscountStrategy("B", 1m)
            };
    }

    [Fact]
    public void Test_Single_Product()
    {
        //arrange
        Cashier cashier = new Cashier(new ProductCatalogue(GetStrategiesABC()));
        cashier.ScanProduct("A");

        //act
        var result = cashier.GetTotalPrice();

        //assert
        Assert.Equal(1m, result);
    }

    [Fact]
    public void Test_Double_Items_Discount()
    {
        Cashier cashier = new Cashier(new ProductCatalogue(GetStrategiesABC()));
        cashier.ScanProducts("A", "A");

        var result = cashier.GetTotalPrice();
        Assert.Equal(1.6m, result);
    }

    [Fact]
    public void Test_Double_Double_Items_Discount()
    {
        Cashier cashier = new Cashier(new ProductCatalogue(GetStrategiesABC()));
        cashier.ScanProducts("A", "A", "A", "A");

        var result = cashier.GetTotalPrice();
        Assert.Equal(3.2m, result);
    }

    [Fact]
    public void Test_Three_Items_Discount()
    {
        Cashier cashier = new Cashier(new ProductCatalogue(GetStrategiesABC()));
        cashier.ScanProducts("B", "B", "B");

        var result = cashier.GetTotalPrice();
        Assert.Equal(3m, result);
    }

    [Fact]
    public void Test_3disc_2disc_1()
    {
        Cashier cashier = new Cashier(new ProductCatalogue(GetStrategiesABC()));
        cashier.ScanProducts("B", "B", "B", "A", "B", "B");

        var result = cashier.GetTotalPrice();
        Assert.Equal(7m, result);
    }

    [Fact]
    public void Test_Double_A_Single_B()
    {
        Cashier cashier = new Cashier(new ProductCatalogue(GetStrategiesABC()));
        cashier.ScanProducts("A", "B", "A");

        var result = cashier.GetTotalPrice();
        Assert.Equal(3.6m, result);
    }

    [Fact]
    public void Test_Double_A_Single_A()
    {
        Cashier cashier = new Cashier(new ProductCatalogue(GetStrategiesABC()));
        cashier.ScanProducts("A", "A", "A");

        var result = cashier.GetTotalPrice();
        Assert.Equal(2.6m, result);
    }
}