
using ProductCalculator;

namespace MSUnitTest;

[TestClass]
public class ProductCalculatorTest
{
    [TestMethod] //bu faqatgina shu methodni ichida test qilish uchun ishlanadi buni ovorsak tesda bunday funkisya yoq deydi
    public void Calculate_NoDiscount_ReturnTotal()
    {
        var productPrice = 10.0;
        var productCount = 5.0;
        var discount = 0;
        var expectedTotalPrice = 50.0;
        var calculator = new ProductPriceCalculator();
        var total = calculator.CalculatePrice(productPrice, productCount, discount);
        Assert.AreEqual(expectedTotalPrice, total);
    } 
    [TestMethod]
    public void Calculate_DiscountedPrice()
    {
        var productPrice = 10.0;
        var productCount = 5.0;
        var discount = 20.0;
        var expectedTotalPrice = 40.0;
        var calculator = new ProductPriceCalculator();
        var total = calculator.CalculatePrice(productPrice, productCount, discount);
        Assert.AreEqual(expectedTotalPrice, total);
    }

    [TestMethod]
    public void Calculate_throwDiscountMoreException()
    {
        var productPrice = 10.0;
        var productCount = 5.0;
        var discount = 101.0;
        var calculator = new ProductPriceCalculator();
        Assert.ThrowsException<DiscountMoreThenExpected>(() =>
        {
            calculator.CalculatePrice(productPrice, productCount, discount);
        }); 
    }
    
}

