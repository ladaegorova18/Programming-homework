using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ParseTree.Tests
{
    [TestClass]
    public class TreeTests
    {
        private Tree tree;

        [TestInitialize]
        public void Initialize()
        {
            tree = new Tree();
        }

        [TestMethod]
        public void OneNumberTest()
        {
            tree.AddString("7");
            Assert.AreEqual(7, tree.Count());
        }

        [TestMethod]
        public void SimpleTaskTest()
        {
            tree.AddString("+ 5 3");
            Assert.AreEqual(8, tree.Count());
        }

        [TestMethod]
        public void ExampleTaskTest()
        {
            tree.AddString("(*(+ 1 1) 2)");
            Assert.AreEqual(4, tree.Count());
        }

        [TestMethod]
        public void TwoBracketsTaskTest()
        {
            tree.AddString("(/(- 9 1)(* 4 1))");
            Assert.AreEqual(2, tree.Count());
        }

        [TestMethod]
        public void AnotherTwoBracketsTaskTest()
        {
            tree.AddString("* (/ 6 2)(- 9 7)");
            Assert.AreEqual(6, tree.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(System.DivideByZeroException))]
        public void DivisionByZeroTest()
        {
            tree.AddString("/ 3 0");
            tree.Count();
        }

        [TestMethod]
        public void NegativeResultTest()
        {
            tree.AddString("- 3 7");
            Assert.AreEqual(-4, tree.Count());
        }

        [TestMethod]
        public void SumOfZeroesTest()
        {
            tree.AddString("+ 0 0");
            Assert.AreEqual(0, tree.Count());
        }

        [TestMethod]
        public void ZeroAsFirstAddendTest()
        {
            tree.AddString("+ 0 6");
            Assert.AreEqual(6, tree.Count());
        }

        [TestMethod]
        public void ZeroAsSecondAddendTest()
        {
            tree.AddString("+ 5 0");
            Assert.AreEqual(5, tree.Count());
        }

        [TestMethod]
        public void RepeatingOperationsTest()
        {
            tree.AddString("(-(-(-(- 7 2)1)1)1)");
            Assert.AreEqual(2, tree.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void WrongStringTest()
        {
            tree.AddString("+(+ 4 3)");
            tree.Count(); 
        }

        [TestMethod]
        public void ZeroTest()
        {
            tree.AddString("0");
            Assert.AreEqual(0, tree.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(System.DivideByZeroException))]
        public void HiddenDivisionByZeroTest()
        {
            tree.AddString("/ 8 (- 5 5))");
            tree.Count();
        }

        [TestMethod]
        public void NegativeNumberTest()
        {
            tree.AddString("-3");
            Assert.AreEqual(-3, tree.Count());
        }
    }
}
