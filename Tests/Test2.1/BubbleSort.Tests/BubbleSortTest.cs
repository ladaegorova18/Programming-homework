using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BubbleSort.Tests
{
    [TestClass]
    public class BubbleSortTest
    {
        [TestMethod]
        public void GreaterNumberTest()
        {
            var intComparator = new IntComparator();
            var bubbleSort = new Test2.BubbleSorting<int>();
            var list = new List<int>();
            var array = new int[] { 4, 2, 1, 5, 4, 3, 7 };
            var result = new int[] { 1, 2, 3, 4, 4, 5, 7 };
            foreach (var cell in array)
            {
                list.Add(cell);
            }
            list = bubbleSort.Sort(list, intComparator);
            for (var i = 0; i < result.Length; ++i)
            {
                Assert.AreEqual(result[i], list[i]);
            }
        }

        [TestMethod]
        public void LongerStringTest()
        {
            var stringComparator = new StringComparator();
            var bubbleSort = new Test2.BubbleSorting<string>();
            var list = new List<string>();
            var array = new string[] { "hey", "I", "love", "bubble", "sorting" };
            var result = new string[] { "I", "hey", "love", "bubble", "sorting" };
            foreach (var cell in array)
            {
                list.Add(cell);
            }
            list = bubbleSort.Sort(list, stringComparator);
            for (var i = 0; i < result.Length; ++i)
            {
                Assert.AreEqual(result[i], list[i]);
            }
        }

        [TestMethod]
        public void DoubleNumberTest()
        {
            var doubleComparator = new DoubleComparator();
            var bubbleSort = new Test2.BubbleSorting<double>();
            var list = new List<double>();
            var array = new double[] { 0, -1, 0.3f, 10.4f, 6 };
            var result = new double[] { -1, 0, 0.3f, 6, 10.4f };
            foreach (var cell in array)
            {
                list.Add(cell);
            }
            list = bubbleSort.Sort(list, doubleComparator);
            for (var i = 0; i < result.Length; ++i)
            {
                Assert.AreEqual(result[i], list[i]);
            }
        }
    }
}
