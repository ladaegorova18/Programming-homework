using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ListMethods.Tests
{
    [TestClass]
    public class MapTests
    {
        private int[] array;
        private List<int> list;
        private Methods methods = new Methods();

        [TestInitialize]
        public void Initialize()
        {
            list = new List<int>() { 2, 1, 4, 5, 3, 3, 1 };
        }

        [TestMethod]
        public void MultiplyByTwoTest()
        {
            array = new int[] { 4, 2, 8, 10, 6, 6, 2 };
            list = methods.Map(list, x => x * 2);
            Assertion(list, array);
        }

        [TestMethod]
        public void AddThreeTest()
        {
            array = new int[] { 5, 4, 7, 8, 6, 6, 4 };
            list = methods.Map(list, x => x + 3);
            Assertion(list, array);
        }

        [TestMethod]
        public void SubtractFiveTest()
        {
            array = new int[] { -3, -4, -1, 0, -2, -2, -4 };
            list = methods.Map(list, x => x - 5);
            Assertion(list, array);
        }

        [TestMethod]
        public void TwoOperationsTest()
        {
            array = new int[] { 6, 4, 10, 12, 8, 8, 4 };
            list = methods.Map(list, x => (x + 1) * 2);
            Assertion(list, array);
        }

        [TestMethod]
        public void AddZeroTest()
        {
            array = new int[] { 2, 1, 4, 5, 3, 3, 1 };
            list = methods.Map(list, x => x + 0);
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
