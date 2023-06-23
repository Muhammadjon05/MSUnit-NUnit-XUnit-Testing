using ProductCalculator;

namespace MSUnitTest;

[TestClass]
public class ProductCalculatorWithTestInitialize
{
    private  ProductPriceCalculator? _productPriceCalculator;

    //[TestInitialize] // bu har safar yangi funkisyaga kirsa calculatordan yangi obyekt olib beradi
    [TestInitialize]
    public  void TestInitialize()
    {
        _productPriceCalculator = new ProductPriceCalculator();
    }

    [DataTestMethod]
    [DataRow(10.0,5.0,0.0,50.0)] // bu holat bu attributelar har bir funksiya bir marta ishledi degani yani har bitta attribute bu bitta test tegani
    [DataRow(10.0,5.0,20.0,40.0)]
    public void Calculate_ReturnsCorrectTotalPrice(double price,double productCount,double discount,double expected)
    {
        var total = _productPriceCalculator!.CalculatePrice(price, productCount, discount);
        Assert.AreEqual(expected,total);
    }

    [TestMethod]
    //[Ignore("Ignored")]
    public void CalculateAll()
    {
        var productPrice = 10.0;
        var productCount = 5.0;
        var productDiscount = 0.0;
        var expected = 50.0;
        var total = _productPriceCalculator.CalculatePrice(productPrice, productCount, productDiscount);
        Assert.AreEqual(expected,total);
    }

    [TestCleanup] //buni yozmasek ham har [TestInitialize] ni ishlatganimiz uchun bu borib yanngi obyek oluradi 
    public  void TestCleanUp()
    {
        _productPriceCalculator = null;
    }
}