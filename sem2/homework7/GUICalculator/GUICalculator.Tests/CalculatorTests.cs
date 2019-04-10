using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GUICalculator.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        private Counter counter = new Counter();
        private Calculator calculator;

        [TestMethod]
        public void SimpleAdditionTest()
        {
            calculator.ReadNumber('1');
            calculator.ReadOperation("+");
            calculator.ReadNumber('2');
            counter.Count()
        }
    }
}
