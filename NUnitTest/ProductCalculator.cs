using ProductCalculator;

namespace NUnitTest;

[TestFixture]
public class ProductCalculator
{
    [Test]
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
    [Test] 
    [Category(("Discounted"))]
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
    [Test]
    [Order(1)] // bu holatda korstadigon bolsak birinchi bu testni qiladi va keyin boshqasini qiladi
    //yani bu attribute birin kettinlikni korsatish uchun ishlatiladi
    [Timeout(1000)] // qanchadir sekunda javob kemasa fail boladi degani bu
    [Retry(4)] // bu ketma ket 4 marta shu testni ishlatib beradi
    
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