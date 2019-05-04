using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenericSet.Tests
{
    [TestClass]
    public class SetTests
    {
        private Set<int> set;
        private int[] array;

        [TestInitialize]
        public void Initialize()
        {
            set = new Set<int>();
        }

        [TestMethod]
        public void AddIntTest()
        {
            array = new[] { 5, 6, 7 };
            set.Add(5);
            set.Add(6);
            set.Add(7);
            var index = 0;
            foreach(var cell in set)
            {
                Assert.AreEqual(array[index], cell);
            }
        }

        [TestMethod]
        public void AddStringTest()
        {
        }

        [TestMethod]
        public void ContainsIntTest()
        {

        }

        [TestMethod]
        public void ContainsStringTest()
        {

        }

        [TestMethod]
        public void CopyToTest()
        {

        }

        [TestMethod]
        public void ExceptWithIntTest()
        {

        }

        [TestMethod]
        public void ExceptWithStringTest()
        {

        }

        [TestMethod]
        public void IntersectWithIntTest()
        {

        }

        [TestMethod]
        public void IntersectWithStringTest()
        {

        }

        [TestMethod]
        public void IsProperSubsetOfIntTest()
        {
            set.Add(1);
            set.Add(2);
            set.Add(3);
            var other = new Set<int>();
            other.Add(1);
            other.Add(2);
            other.Add(3);
            other.Add(5);
            var result = set.IsProperSubsetOf(other);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsProperSubsetOfStringTest()
        {

        }

        [TestMethod]
        public void IsProperSupersetOfIntTest()
        {

        }

        [TestMethod]
        public void IsProperSupersetOfStringTest()
        {

        }

        [TestMethod]
        public void IsSubsetOfIntTest()
        {

        }

        [TestMethod]
        public void IsSubsetOfStringTest()
        {

        }

        [TestMethod]
        public void IsSupersetOfIntTest()
        {

        }

        [TestMethod]
        public void IsSupersetOfStringTest()
        {

        }

        [TestMethod]
        public void OverlapsIntTest()
        {

        }

        [TestMethod]
        public void OverlapsStringTest()
        {

        }

        [TestMethod]
        public void RemoveIntTest()
        {

        }

        [TestMethod]
        public void RemoveStringTest()
        {

        }

        [TestMethod]
        public void SetEqualsIntTest()
        {

        }

        [TestMethod]
        public void SetEqualsStringTest()
        {

        }

        [TestMethod]
        public void SymmetricExceptWithIntTest()
        {

        }

        [TestMethod]
        public void SymmetricExceptWithStringTest()
        {

        }

        [TestMethod]
        public void UnionWithIntTest()
        {

        }

        [TestMethod]
        public void UnionWithStringTest()
        {

        }

        [TestMethod]
        public void EnumeratorTest()
        {

        }
    }
}
