using NUnit.Framework;

namespace ChineseNumbers.Tests
{
    public class ChineseNumbersTests
    {
        private ChineseNumbersFactory chineseNumbersFactory;

        [SetUp]
        public void Setup()
        {
            chineseNumbersFactory = new ChineseNumbersFactory();
        }

        [Test]
        public void Test1()
        {
            Assert.AreEqual("一百二十三", chineseNumbersFactory.ToFullChineseNumberQuantity(123));
        }
    }
}