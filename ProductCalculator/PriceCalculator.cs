namespace ProductCalculator;

public class ProductPriceCalculator
{
    public double CalculatePrice(double productPrice, double productCount, double discount)
    {
        if (discount > 100)
        {
            throw new DiscountMoreThenExpected(discount);
        }

        var total = productCount * productPrice;
        return total - (discount * total) / 100; 
    }
}
public class DiscountMoreThenExpected : Exception
{
    public DiscountMoreThenExpected(double discount): base($"Given {discount} is more then expected.Max 100%")
    {
        
    }
}