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
    }
}
