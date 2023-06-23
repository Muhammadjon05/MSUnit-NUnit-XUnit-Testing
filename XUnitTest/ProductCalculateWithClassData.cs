using ProductCalculator;

namespace XUnitTest;

public class ProductCalculateWithClassData : TheoryData<double,double,double,double>
{
    public ProductCalculateWithClassData()
    {
        Add(10.0,5.0,0.0,50.0);
        Add(10.0,5.0,20.0,40.0);
    }

    [Theory]
    [ClassData(typeof(ProductCalculateWithClassData))]
    public void Calculations(double price, double count, double discount, double expected)
    {
        var calculator = new ProductPriceCalculator();
        var total = calculator.CalculatePrice(price, count, discount);
        Assert.Equal(expected,total);
    }
}
