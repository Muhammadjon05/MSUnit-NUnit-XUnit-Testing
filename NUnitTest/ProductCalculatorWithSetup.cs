using ProductCalculator;

namespace NUnitTest;

[TestFixture]
public class ProductCalculatorWithSetup
{
    private ProductPriceCalculator? _productPriceCalculator;
   
    [SetUp]
    public  void TestInitialize()
    {
        _productPriceCalculator = new ProductPriceCalculator();
    }

    [TestCase(10.0, 5.0, 0.0, 50.0)]
    [TestCase(10.0, 5.0, 20.0, 40.0)]
    public void CalculateWithoutDiscount(double productPrice, double productCount, double productDiscount,
        double expected)
    {
        var total = _productPriceCalculator.CalculatePrice(productPrice, productCount, productDiscount);
        Assert.That(total, Is.EqualTo(expected));
    }

    [TestCase(10.0, 5.0, 101.0)]
    //[Ignore("Ignore")]
    public void CalculateWithDiscountMore(double productPrice, double productCount, double productDiscount)
    {
        Assert.Throws<DiscountMoreThenExpected>(() =>
        {
            _productPriceCalculator.CalculatePrice(productPrice, productCount, productDiscount);
        });
    }

    [TearDown]
    // agar class boyicha bitta obyekt olmasak bizga Method Boyicha olganimzda
    public void TearDown()
    {
        _productPriceCalculator = null;
    }
}