using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GUICalculator.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        private Counter counter = new Counter();

        [TestMethod]
        public void AdditionTest()
        {
            var result = counter.Count(4, 5, "+");
            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void SubtractionTest()
        {
            var result = counter.Count(54, 9, "-");
            Assert.AreEqual(45, result);
        }

        [TestMethod]
        public void DivisionTest()
        {
            var result = counter.Count(1, 2, "/");
            Assert.AreEqual(0.5, result);
        }

        [TestMethod]
        public void MultiplicationTest()
        {
            var result = counter.Count(8, 12, "*");
            Assert.AreEqual(96, result);
        }

        [TestMethod]
        public void ZeroesAdditionTest()
        {
            var result = counter.Count(0, 0, "+");
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZeroTest()
        {
            var result = counter.Count(9, 0, "/");
        }

        [TestMethod]
        public void NegativeNumbersAdditionTest()
        {
            var result = counter.Count(-5, -8, "+");
            Assert.AreEqual(-13, result);
        }

        [TestMethod]
        public void NegativeAndPositiveAdditionTest()
        {
            var result = counter.Count(-3, 6, "+");
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void NegativeNumbersMultiplicationTest()
        {
            var result = counter.Count(-2, -4, "*");
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void NegativeAndPositiveMultiplicationTest()
        {
            var result = counter.Count(-7, 3, "*");
            Assert.AreEqual(-21, result);
        }

        [TestMethod]
        public void NegativeNumbersDivisionTest()
        {
            var result = counter.Count(-3, -4, "/");
            Assert.AreEqual(0.75, result);
        }

        [TestMethod]
        public void NegativeAndPositiveDivisionTest()
        {
            var result = counter.Count(-8, 4, "/");
            Assert.AreEqual(-2, result);
        }

        [TestMethod]
        public void NegativeNumbersSubtractionTest()
        {
            var result = counter.Count(-2, -40, "-");
            Assert.AreEqual(38, result);
        }

        [TestMethod]
        public void NegativeAndPositiveSubtractionTest()
        {
            var result = counter.Count(82, -43, "-");
            Assert.AreEqual(125, result);
        }
    }
}
