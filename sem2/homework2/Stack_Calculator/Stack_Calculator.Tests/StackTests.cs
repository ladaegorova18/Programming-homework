using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StackCalculator.Tests
{
    [TestClass]
    public class StackTests
    {
        public void PushTest(IStack stack)
        {
            stack.Push('1');
            Assert.IsFalse(stack.IsEmpty);
        }

        public void PopTest(IStack stack)
        {
            stack.Push('3');
            stack.Pop();
            Assert.IsTrue(stack.IsEmpty);
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
}
