using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductCalculator;

namespace MSUnitTest
{
    [TestClass]
    public class ClassInitialize
    {
        private static ProductPriceCalculator _productPrice;

        [ClassInitialize] // bu holatdan _productPrice dan bir marta abyekt oldai va u class miqdorida saqlanib qoladi
                          // TestInitialize da boladigon bolsa bu har safar kelib yangi abyek olib ketadi
        public static void TestInitialize(TestContext context)
        {
            _productPrice = new ProductPriceCalculator();
        }

        [DataTestMethod]
        [DataRow(10.0, 5.0, 0.0, 50.0)]
        [DataRow(10.0, 5.0, 20.0, 40.0)]
        public void Calculate_ReturnsCorrectTotalPrice(double price, double productCount, double discount, double expected)
        {
            var total = _productPrice.CalculatePrice(price, productCount, discount);
            Assert.AreEqual(expected, total);
        }

        [TestMethod]
        [Ignore("Ignored")]
        public void CalculateAll()
        {
            var productPrice = 10.0;
            var productCount = 5.0;
            var productDiscount = 0.0;
            var expected = 50.0;
            var total = _productPrice.CalculatePrice(productPrice, productCount, productDiscount);
            Assert.AreEqual(expected, total);
        }

        [ClassCleanup] // bu ishlamasa ham ozi ishloradi  bu yoq bolsa ham
        public static void TestCleanUp()
        {
            _productPrice = null;
        }
    }
}
