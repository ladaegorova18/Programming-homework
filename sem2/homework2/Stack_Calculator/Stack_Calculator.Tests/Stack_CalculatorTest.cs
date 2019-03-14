using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stack_Calculator.Tests
{
    [TestClass]
    public class StackTests
    {
        public void PushTest(IStack stack)
        {
            stack.Push('1');
            Assert.IsFalse(stack.IsEmpty());
        }

        public void PopTest(IStack stack)
        {
            stack.Push('3');
            stack.Pop();
            Assert.IsTrue(stack.IsEmpty());
        }

        public void PopFromEmptyTest(IStack stack)
        {
            stack.Pop();
        }

        public void PopValueTest(IStack stack)
        {
            stack.Push('2');
            Assert.AreEqual('2', stack.Pop());
        }

        public void TwoValuesPopTest(IStack stack)
        {
            stack.Push('1');
            stack.Push('2');
            var secondValue = stack.Pop();
            var firstValue = stack.Pop();
            Assert.AreEqual('2', secondValue);
            Assert.AreEqual('1', firstValue);
        }

        [TestInitialize]
        public void Initialize()
        {
            stackArray = new StackArray();
            stackList = new StackList();
        }

        [TestCleanup]
        public void CleanUp()
        {
            stackArray.Clear();
            stackList.Clear();
        }

        [TestMethod]
        public void PushTestForStackList()
            => PushTest(stackList);

        [TestMethod]
        public void PushTestForStackArray()
            => PushTest(stackArray);

        [TestMethod]
        public void PopTestForStackList()
            => PopTest(stackList);

        [TestMethod]
        public void PopTestForStackArray()
            => PopTest(stackArray);

        [TestMethod]
        void PopFromEmptyTestForStackList()
            => PopFromEmptyTest(stackList);

        [TestMethod]
        void PopFromEmptyTestForStackArray()
            => PopFromEmptyTest(stackArray);

        [TestMethod]
        void PopValueTestForStackList()
            => PopValueTest(stackList);

        [TestMethod]
        void PopValueTestForStackArray()
            => PopValueTest(stackArray);

        [TestMethod]
        public void TwoValuesPopTestForStackList()
            => TwoValuesPopTest(stackList);

        [TestMethod]
        public void TwoValuesPopTestForStackArray()
            => TwoValuesPopTest(stackArray);

        private StackArray stackArray;
        private StackList stackList;
    }

    [TestClass]
    public class Stack_CalculatorTests
    {
        public void Sum_5and4_Test(IStack stack)
        {
            var result = calculator.Count("5 4 +", stack);
            Assert.AreEqual(9, result);
        }

        public void Subtraction_6and1_Test(IStack stack)
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
            calculator.Count("5 9 -", stack);
        }

        public void IncorrectInputTest(IStack stack)
        {
            calculator.Count("lololo", stack);
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
        public void Sum_5and4_TestStackArray()
            => Sum_5and4_Test(stackArray);

        [TestMethod]
        public void Sum_5and4_TestStackList()
            => Sum_5and4_Test(stackList);

        [TestMethod]
        public void Subtraction_6and1_TestForStackArray()
            => Subtraction_6and1_Test(stackArray);

        [TestMethod]
        public void Subtraction_6and1_TestForStackList()
            => Subtraction_6and1_Test(stackList);

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
        public void IncorrectInputTestForStackArray()
            => IncorrectInputTest(stackArray);

        [TestMethod]
        public void IncorrectInputTestForStackList()
            => IncorrectInputTest(new StackList());

        [TestMethod]
        public void BalanceOperationsTestForStackArray()
            => BalanceOperationsTest(new StackArray());

        [TestMethod]
        public void BalanceOperationsTestForStackList()
            => BalanceOperationsTest(new StackList());

        private Calculator calculator;
        private StackArray stackArray;
        private StackList stackList;
    }
}
