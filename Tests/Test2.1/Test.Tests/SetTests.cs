using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test2.Tests
{
    [TestClass]
    public class SetTests
    {
        [TestMethod]
        public void ComparatorTest()
        {
            var list1 = new List<int>();
            var list2 = new List<int>();
            list1.Add(3);
            list2.Add(4);
            list2.Add(2);
            var comparer = new ListComparator<int>();
            Assert.AreEqual(-1, comparer.Compare(list1, list2));
        }

        [TestMethod]
        public void SetTest()
        {
            var list1 = new List<string>();
            var list2 = new List<string>();
            var comparer = new ListComparator<string>();
            var set = new SortedSet<string>(comparer);
            list1.Add("help");
            list1.Add("I");
            list2.Add("need");
            list2.Add("somebody");
            list2.Add("help");
            set.Add(list2);
            set.Add(list1);
            var array = new[] { "need", "somebody", "help", "help", "I" };
        }

        //private void Assertion(string array, SortedSet<string> set)
        //{
        //    var i = 0;
        //    foreach (var list in set)
        //    {
        //        foreach (var word in list)
        //        {
        //            Assert.AreEqual(array[i], word);
        //            ++i;
        //        }
        //    }
        //}
    }
}
