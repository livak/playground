using DataStructures.Stacks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.Test.Stacks
{
    [TestClass]
    public class PostfixCalculatorTests
    {
        [TestMethod]
        public void Test()
        {
            // 5 + 6 * 7 - 1
            var tokens = new[] { "5", "6", "7", "*", "+", "1", "-" };
            Assert.AreEqual(46, PostfixCalculator.Calculate(tokens));
        }
    }
}
