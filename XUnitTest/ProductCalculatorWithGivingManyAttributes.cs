using ProductCalculator;

namespace XUnitTest;

public class ProductCalculatorWithGivingManyAttributes
{
    private readonly ProductPriceCalculator? _productPriceCalculator;

    public ProductCalculatorWithGivingManyAttributes()
    {
        _productPriceCalculator = new ProductPriceCalculator();
    }

    [Theory]
    [InlineData(10.0, 5.0, 0.0, 50.0)]
    [InlineData(10.0, 5.0, 20.0, 40.0)]
    public void CalculateWithDiscounAndWithout(double price, double count, double discount, double expected)
    {
        var total = _productPriceCalculator.CalculatePrice(price, count, discount);
        Assert.Equal(expected, total);
    }

    [Theory]
    [InlineData(10.0, 5.0, 102.0)]
    public void CalculateWithThrowsException(double price, double count, double discount)
    {
        Assert.Throws<DiscountMoreThenExpected>(() =>
            _productPriceCalculator.CalculatePrice(price, count, discount));
    }

    
    
    
    //Bu funkisyada siz hohlagan joyingizda malumotni olib bu yerda inline data uchun ishlatsangiz boladi
    //yani bu degan hohlasangiz database dan malumot olib bu yerga qoysangiz boladi bu hardoim STATIC bolishi kere
    //foydanlanishda esa  [MemberData("CalculatePriceTheoryData")] va shu classni ichida bolishi kere
    public static TheoryData<double, double, double, double> CalculatePriceTheoryData()
    {
        var test = new TheoryData<double, double, double, double>()
        {
            { 10.0, 5.0, 0.0, 50.0 },
            { 10.0, 5.0, 20.0, 40.0 }
        };
        return test;
    }

    [Theory]
    [MemberData(nameof(CalculatePriceTheoryData))]
    public void CalculateWithMemberData(
        double price,
        double count,
        double discount,
        double expected
        )
    {
        var total = _productPriceCalculator.CalculatePrice(price, count, discount);
        Assert.Equal(expected,total);
    }
 
}
