namespace models;

public interface IPricingStrategy
{
    string Sku { get; }
    int ProductsTresholdCount { get; }
    decimal GetPrice(int count);

}

