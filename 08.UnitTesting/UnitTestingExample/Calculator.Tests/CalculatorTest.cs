using Calculators;

namespace Calculator.Tests
{
    [TestFixture]
    class CalculatorTest
    {
        [Test]
        [TestCase(5,6)]
        [TestCase(100,3)]
        [TestCase(5,6)]
        public void CalculatorAdd_ShouldReturnCorrectly(int a, int b)
        {
            Calculators.Calculator calculator = new Calculators.Calculator();
            int result = calculator.Add(a, b);
            Assert.AreEqual(a + b, result, $"Adding {a} and {b} should return {a + b} and not {result}");
        }

        [Test]
        public void SecondTest()
        {

        }
    }
}
