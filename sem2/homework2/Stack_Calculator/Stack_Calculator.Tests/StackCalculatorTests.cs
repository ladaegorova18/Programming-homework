using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StackCalculator.Tests
{
    [TestClass]
    public class StackCalculatorTests
    {
        private Calculator calculator;
        private StackArray stackArray;
        private StackList stackList;

        public void Sum5and4Test(IStack stack)
        {
            var result = calculator.Count("5 4 +", stack);
            Assert.AreEqual(9, result);
        }

        public void Subtraction6and1Test(IStack stack)
        {
            var result = calculator.Count("6 5 -", stack);
            Assert.AreEqual(1, result);
        }

        public void TwoOperationsTest(IStack stack)
        {
            var result = calculator.Count("9 1 - 2 /", stack);
            Assert.AreEqual(4, result);
        }

        public void TwoZeroesSumTest(IStack stack)
        {
            var result = calculator.Count("0 0 +", stack);
            Assert.AreEqual(0, result);
        }

        public void NegativeResultTest(IStack stack)
        {
            var result = calculator.Count("5 9 -", stack);
            Assert.AreEqual(-4, result);
        }

        public void IncorrectInputTest(IStack stack)
        {
            var result = calculator.Count("lololo", stack);
        }

        public void BalanceOperationsTest(IStack stack)
        {
            calculator.Count("4 6 5 4 - *", stack);
        }

        [TestInitialize]
        public void Initialize()
        {
            calculator = new Calculator();
            stackList = new StackList();
            stackArray = new StackArray();
        }

        [TestCleanup]
        public void CleanUp()
        {
            stackList.Clear();
            stackArray.Clear();
        }

        [TestMethod]
        public void Sum5and4TestStackArray()
            => Sum5and4Test(stackArray);

        [TestMethod]
        public void Sum5and4TestStackList()
            => Sum5and4Test(stackList);

        [TestMethod]
        public void Subtraction6and1TestForStackArray()
            => Subtraction6and1Test(stackArray);

        [TestMethod]
        public void Subtraction6and1TestForStackList()
            => Subtraction6and1Test(stackList);

        [TestMethod]
        public void TwoOperationsTestForStackArray()
            => TwoOperationsTest(stackArray);

        [TestMethod]
        public void TwoOperationsTestForStackList()
            => TwoOperationsTest(stackList);

        [TestMethod]
        public void TwoZeroesSumTestForStackArray()
            => TwoZeroesSumTest(stackArray);

        [TestMethod]
        public void TwoZeroesSumTestForStackList()
            => TwoZeroesSumTest(stackList);

        [TestMethod]
        public void NegativeResultTestForStackArray()
            => NegativeResultTest(stackArray);

        [TestMethod]
        public void NegativeResultTestForStackList()
            => NegativeResultTest(stackList);

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void IncorrectInputTestForStackArray()
            => IncorrectInputTest(stackArray);

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void IncorrectInputTestForStackList()
            => IncorrectInputTest(new StackList());

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void BalanceOperationsTestForStackArray()
            => BalanceOperationsTest(new StackArray());

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void BalanceOperationsTestForStackList()
            => BalanceOperationsTest(new StackList());
    }
}
