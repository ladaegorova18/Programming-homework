using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ListMethods.Tests
{
    [TestClass]
    public class FilterTests
    {
        private int[] array;
        private List<int> list;

        [TestInitialize]
        public void Initialize()
        {
            list = new List<int>() { 2, 1, 4, 5, 3, 3, 1, 7, 6, 9, 3, 0 };
        }

        [TestMethod]
        public void FilterEvenNumbersTest()
        {
            array = new int[] { 2, 4, 6, 0};
            list = Methods.Filter(list, x => (x % 2 == 0));
            Assertion(list, array);
        }

        [TestMethod]
        public void FilterLess5NumberTest()
        {
            array = new int[] { 2, 1, 4, 3, 3, 1, 3, 0 };
            list = Methods.Filter(list, x => (x < 5));
            Assertion(list, array);
        }

        [TestMethod]
        public void FilterDivide3Test()
        {
            array = new int[] { 6, 9, 0 };
            list = Methods.Filter(list, x => (x % 3 == 0 && x != 3));
            Assertion(list, array);
        }

        [TestMethod]
        public void FilterOddNumbersTest()
        {
            array = new int[] { 1, 5, 3, 3, 1, 7, 9, 3 };
            list = Methods.Filter(list, x => (x % 2 == 1));
            Assertion(list, array);
        }

        [TestMethod]
        public void FilterLess7AndGreater3Test()
        {
            array = new int[] {4, 5, 6};
            list = Methods.Filter(list, x => (x > 3 && x < 7));
            Assertion(list, array);
        }

        private void Assertion(List<int> list, int[] array)
        {
            for (var i = 0; i < list.Count; ++i)
            {
                Assert.AreEqual(array[i], list[i]);
            }
        }
    }
}
