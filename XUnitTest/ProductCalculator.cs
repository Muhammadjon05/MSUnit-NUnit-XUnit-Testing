using ProductCalculator;

namespace XUnitTest;
//va  bunda classni attributini berish ham shart emas  [TestFixture] [TestClass] ga ohshab 
public class ProductCalculator
{
    private readonly ProductPriceCalculator _productPriceCalculator;
    //bunda MSunitga ohshab [TestInitialize] yoki NUnit ga ohshab [SetUp] emas bunda Constructorda
    public ProductCalculator()
    {
        _productPriceCalculator = new ProductPriceCalculator();
    }

    [Fact]
    public void Calculate_NoDiscount_ReturnTotal()
    {
        var productPrice = 10.0;
        var productCount = 5.0;
        var discount = 0;
        var expectedTotalPrice = 50.0;
        var calculator = new ProductPriceCalculator();
        var total = calculator.CalculatePrice(productPrice, productCount, discount);
        Assert.Equal(expectedTotalPrice, total);
    } 
    [Fact]
    public void Calculate_DiscountedPrice()
    {
        var productPrice = 10.0;
        var productCount = 5.0;
        var discount = 20.0;
        var expectedTotalPrice = 40.0;
        var calculator = new ProductPriceCalculator();
        var total = calculator.CalculatePrice(productPrice, productCount, discount);
        Assert.Equal(expectedTotalPrice, total);
    }
    [Fact]
    public void Calculate_throwDiscountMoreException()
    {
        var productPrice = 10.0;
        var productCount = 5.0;
        var discount = 101.0;
        var calculator = new ProductPriceCalculator();
        Assert.Throws<DiscountMoreThenExpected>(() =>
        {
            calculator.CalculatePrice(productPrice, productCount, discount);
        }); 
    }
}