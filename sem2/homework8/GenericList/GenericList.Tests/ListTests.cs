using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenericList.Tests
{
    /// <summary>
    /// class of unit-tests
    /// </summary>
    [TestClass]
    public class ListTests
    {
        private List<int> listInt;
        private List<string> listString;

        [TestInitialize]
        public void Initialize()
        {
            listInt = new List<int>();
            listString = new List<string>();
        }

        [TestMethod]
        public void AddTest()
        {
            var array = new [] { 3, 2, 1 };
            listInt.Add(3);
            listInt.Add(2);
            listInt.Add(1);
            var index = 0;
            foreach (var cell in listInt)
            {
                Assert.AreEqual(array[index], cell);
                ++index;
            }
        }

        [TestMethod]
        public void RemoveIntTest()
        {
            listInt.Add(1);
            Assert.AreEqual(1, listInt.Count);
            listInt.Remove(1);
            Assert.AreEqual(0, listInt.Count);
        }

        [TestMethod]
        public void RemoveStringTest()
        {
            listString.Add("1");
            Assert.AreEqual(1, listString.Count);
            listString.Remove("1");
            Assert.AreEqual(0, listString.Count);
        }

        [TestMethod]
        public void InsertTest()
        {
            var array = new [] { 1, 9, 2 };
            listInt.Add(1);
            listInt.Add(2);
            listInt.Insert(1, 9);
            var index = 0;
            foreach (var cell in listInt)
            {
                Assert.AreEqual(array[index], cell);
                ++index;
            }
        }

        [TestMethod]
        public void IndexOfIntTest()
        {
            listInt.Add(1);
            listInt.Add(2);
            listInt.Add(3);
            Assert.AreEqual(2, listInt.IndexOf(3));
            Assert.AreEqual(1, listInt.IndexOf(2));
            Assert.AreEqual(0, listInt.IndexOf(1));
        }

        [TestMethod]
        public void IndexOfStringTest()
        {
            listString.Add("1");
            listString.Add("2");
            listString.Add("3");
            Assert.AreEqual(2, listString.IndexOf("3"));
            Assert.AreEqual(1, listString.IndexOf("2"));
            Assert.AreEqual(0, listString.IndexOf("1"));
        }

        [TestMethod]
        public void RemoveAtTest()
        {
            listInt.Add(1);
            listInt.Add(2);
            listInt.RemoveAt(1);
            Assert.IsFalse(listInt.Contains(2));
        }

        [TestMethod]
        public void ContainsIntTest()
        {
            Assert.IsFalse(listInt.Contains(1));
            listInt.Add(1);
            Assert.IsTrue(listInt.Contains(1));
        }

        [TestMethod]
        public void ContainsStringTest()
        {
            Assert.IsFalse(listString.Contains("1"));
            listString.Add("1");
            Assert.IsTrue(listString.Contains("1"));
        }

        [TestMethod]
        public void CopyToTest()
        {
            var array = new int[3];
            var result = new [] { 1, 2, 3 };
            listInt.Add(1);
            listInt.Add(2);
            listInt.Add(3);
            listInt.CopyTo(array, 0);
            for (var i = 0; i < 3; ++i)
            {
                Assert.AreEqual(array[i], result[i]);
            }
        }

        [TestMethod]
        public void EnumeratorTest()
        {
            var array = new [] { 1, 2, 3 };
            listInt.Add(1);
            listInt.Add(2);
            listInt.Add(3);
            var ie = listInt.GetEnumerator();
            var index = 0;
            while (ie.MoveNext())
            {
                Assert.AreEqual(array[index], ie.Current);
                ++index;
            }
        }
    }
}
