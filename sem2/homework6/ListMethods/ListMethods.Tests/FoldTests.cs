using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ListMethods.Tests
{
    [TestClass]
    public class FoldTests
    { 
        private List<int> list = new List<int>{ 2, 1, 4, 5, 3, 3};
        private Methods methods = new Methods();

        [TestMethod]
        public void FoldByMultiplicationTest()
        {
            var result = methods.Fold(list, 1, (acc, elem) => acc * elem);
            Assert.AreEqual(360, result);
        }

        [TestMethod]
        public void FoldBySubtractionTest()
        {
            var result = methods.Fold(list, 0, (acc, elem) => acc - elem);
            Assert.AreEqual(-18, result);
        }

        [TestMethod]
        public void FoldByAdditionTest()
        {
            var result = methods.Fold(list, 0, (acc, elem) => acc + elem);
            Assert.AreEqual(18, result);
        }

        [TestMethod]
        public void FoldByAdditionSquares()
        {
            var result = methods.Fold(list, 0, (acc, elem) => acc + elem * elem);
            Assert.AreEqual(64, result);
        }

        [TestMethod]
        public void FoldByComplexFunction()
        {
            int func(int acc, int elem)
            {
                if (elem % 2 == 0)
                {
                    return acc + elem;
                }
                return acc;
            }
            var result = methods.Fold(list, 0, func);
            Assert.AreEqual(6, result);
        }
    }
}
