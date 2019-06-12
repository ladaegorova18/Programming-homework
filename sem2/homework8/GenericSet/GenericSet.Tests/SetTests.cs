using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenericSet.Tests
{
    [TestClass]
    public class SetTests
    {
        private Set<int> intSet;
        private Set<string> stringSet;

        [TestInitialize]
        public void Initialize()
        {
            intSet = new Set<int>();
            stringSet = new Set<string>();
        }

        [TestMethod]
        public void AddIntTest()
        {
            var array = new[] { 141, 142, 143, 144 };
            intSet.Add(141);
            intSet.Add(142);
            intSet.Add(143);
            intSet.Add(144);
            var index = 0;
            foreach (var cell in intSet)
            {
                Assert.AreEqual(array[index], cell);
                ++index;
            }
        }

        [TestMethod]
        public void AddStringTest()
        {
            var array = new[] { "one", "two", "three" };
            stringSet.Add("one");
            stringSet.Add("two");
            stringSet.Add("three");
            var index = 0;
            foreach (var cell in stringSet)
            {
                Assert.AreEqual(array[index], cell);
                ++index;
            }
        }

        [TestMethod]
        public void AddTheSameValueIntTest()
        {
            intSet.Add(5);
            intSet.Add(5);
            intSet.Add(5);
            intSet.Add(5);
            Assert.AreEqual(1, intSet.Count);
            Assert.IsTrue(intSet.Contains(5));
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void NullSecondException()
        {
            intSet.Add(1);
            Set<int> nullSet = null;
            intSet.ExceptWith(nullSet);
        }


        [TestMethod]
        public void AddTheSameValueStringTest()
        {
            stringSet.Add("Thor");
            stringSet.Add("Thor");
            stringSet.Add("Thor");
            stringSet.Add("Thor");
            Assert.AreEqual(1, stringSet.Count);
            Assert.IsTrue(stringSet.Contains("Thor"));
        }

        [TestMethod]
        public void ContainsIntTest()
        {
            Assert.IsFalse(intSet.Contains(5));
            intSet.Add(5);
            Assert.IsTrue(intSet.Contains(5));
        }

        [TestMethod]
        public void ContainsStringTest()
        {
            Assert.IsFalse(stringSet.Contains("ololo"));
            stringSet.Add("ololo");
            Assert.IsTrue(stringSet.Contains("ololo"));
        }

        [TestMethod]
        public void CopyToTest()
        {
            var array = new[] { 7, 4, 3, 2, 8 };
            intSet.Add(7);
            intSet.Add(4);
            intSet.Add(3);
            intSet.Add(2);
            intSet.Add(8);
            var result = new int[5];
            intSet.CopyTo(result, 0);
            for (var i = 0; i < result.Length; ++i)
            {
                Assert.AreEqual(array[i], result[i]);
            }
        }

        [TestMethod]
        public void ExceptWithIntTest()
        {
            var addToFirst = new[] { 0, 1, 2, 3, 4, 5 };
            var addToSecond = new[] { 3, 4, 5, 6, 7, 8 };
            var result = new[] { 0, 1, 2 };
            var secondSet = new Set<int>();
            for (var i = 0; i < 6; ++i)
            {
                intSet.Add(addToFirst[i]);
                secondSet.Add(addToSecond[i]);
            }
            intSet.ExceptWith(secondSet);
            IntAssertion(result);
            Assert.AreEqual(3, intSet.Count);
        }

        [TestMethod]
        public void ExceptWithStringTest()
        {
            var addToFirst = new[] { "Tony", "Steve", "Natasha", "Bruce" };
            var addToSecond = new[] { "Vision", "Tony", "Natasha", "Stan" };
            var result = new[] { "Steve", "Bruce" };
            var secondSet = new Set<string>();
            for (var i = 0; i < 4; ++i)
            {
                stringSet.Add(addToFirst[i]);
                secondSet.Add(addToSecond[i]);
            }
            stringSet.ExceptWith(secondSet);
            StringAssertion(result);
            Assert.AreEqual(2, stringSet.Count);
        }

        [TestMethod]
        public void IntersectWithIntTest()
        {
            var addToFirst = new[] { 0, 1, 2, 3, 4, 5 };
            var addToSecond = new[] { 3, 4, 5, 6, 7, 8 };
            var result = new[] { 3, 4, 5 };
            var secondSet = new Set<int>();
            for (var i = 0; i < 6; ++i)
            {
                intSet.Add(addToFirst[i]);
                secondSet.Add(addToSecond[i]);
            }
            intSet.IntersectWith(secondSet);
            IntAssertion(result);
            Assert.AreEqual(3, intSet.Count);
        }

        [TestMethod]
        public void IntersectWithStringTest()
        {
            var addToFirst = new[] { "Tony", "Steve", "Natasha", "Bruce" };
            var addToSecond = new[] { "Vision", "Tony", "Natasha", "Stan" };
            var result = new[] { "Tony", "Natasha" };
            var secondSet = new Set<string>();
            for (var i = 0; i < 4; ++i)
            {
                stringSet.Add(addToFirst[i]);
                secondSet.Add(addToSecond[i]);
            }
            stringSet.IntersectWith(secondSet);
            StringAssertion(result);
            Assert.AreEqual(2, stringSet.Count);
        }

        [TestMethod]
        public void IsProperSubsetOfIntTest()
        {
            var addToFirst = new[] { 3, 4, 5 };
            var addToSecond = new[] { 3, 4, 5, 6};
            var secondSet = new Set<int>();
            foreach (var cell in addToFirst)
            {
                intSet.Add(cell);
            }
            foreach (var cell in addToSecond)
            {
                secondSet.Add(cell);
            }
            Assert.IsTrue(intSet.IsProperSubsetOf(secondSet));
            secondSet.Remove(6);
            Assert.IsFalse(intSet.IsProperSubsetOf(secondSet));
        }

        [TestMethod]
        public void IsProperSubsetOfStringTest()
        {
            var addToFirst = new[] { "Jon", "Arya", "Sansa" };
            var addToSecond = new[] { "Jon", "Arya", "Sansa", "Bran" };
            var secondSet = new Set<string>();
            foreach (var cell in addToFirst)
            {
                stringSet.Add(cell);
            }
            foreach (var cell in addToSecond)
            {
                secondSet.Add(cell);
            }
            Assert.IsTrue(stringSet.IsProperSubsetOf(secondSet));
            secondSet.Remove("Bran");
            Assert.IsFalse(stringSet.IsProperSubsetOf(secondSet));
        }

        [TestMethod]
        public void IsProperSupersetOfIntTest()
        {
            var addToFirst = new[] { 3, 4, 5, 6 };
            var addToSecond = new[] { 3, 4, 5 };
            var secondSet = new Set<int>();
            foreach (var cell in addToFirst)
            {
                intSet.Add(cell);
            }
            foreach (var cell in addToSecond)
            {
                secondSet.Add(cell);
            }
            Assert.IsTrue(intSet.IsProperSupersetOf(secondSet));
            intSet.Remove(6);
            Assert.IsFalse(intSet.IsProperSupersetOf(secondSet));
        }

        [TestMethod]
        public void IsProperSupersetOfStringTest()
        {
            var addToFirst = new[] { "Jon", "Arya", "Sansa", "Bran" };
            var addToSecond = new[] { "Jon", "Arya", "Sansa" };
            var secondSet = new Set<string>();
            foreach (var cell in addToFirst)
            {
                stringSet.Add(cell);
            }
            foreach (var cell in addToSecond)
            {
                secondSet.Add(cell);
            }
            Assert.IsTrue(stringSet.IsProperSupersetOf(secondSet));
            stringSet.Remove("Bran");
            Assert.IsFalse(stringSet.IsProperSupersetOf(secondSet));
        }

        [TestMethod]
        public void IsSubsetOfIntTest()
        {
            var addToFirst = new[] { 5, 4, 3 };
            var addToSecond = new[] { 3, 4, 5, 6, 7, 8 };
            var secondSet = new Set<int>();
            foreach (var cell in addToFirst)
            {
                intSet.Add(cell);
            }
            foreach (var cell in addToSecond)
            {
                secondSet.Add(cell);
            }
            Assert.IsTrue(intSet.IsSubsetOf(secondSet));
            intSet.Remove(4);
            Assert.IsTrue(intSet.IsSubsetOf(secondSet));
        }

        [TestMethod]
        public void IsSubsetOfStringTest()
        {
            var addToFirst = new[] { "Sansa", "Jon", "Arya"};
            var addToSecond = new[] { "Jon", "Arya", "Sansa", "Bran" };
            var secondSet = new Set<string>();
            foreach (var cell in addToFirst)
            {
                stringSet.Add(cell);
            }
            foreach (var cell in addToSecond)
            {
                secondSet.Add(cell);
            }
            Assert.IsTrue(stringSet.IsSubsetOf(secondSet));
            stringSet.Remove("Arya");
            Assert.IsTrue(stringSet.IsSubsetOf(secondSet));
        }

        [TestMethod]
        public void IsSupersetOfIntTest()
        {
            var addToFirst = new[] { 3, 4, 5, 6, 7, 8 };
            var addToSecond = new[] { 4, 5, 3 };
            var secondSet = new Set<int>();
            foreach (var cell in addToFirst)
            {
                intSet.Add(cell);
            }
            foreach (var cell in addToSecond)
            {
                secondSet.Add(cell);
            }
            Assert.IsTrue(intSet.IsSupersetOf(secondSet));
            secondSet.Remove(4);
            Assert.IsTrue(intSet.IsSupersetOf(secondSet));
        }

        [TestMethod]
        public void IsSupersetOfStringTest()
        {
            var addToFirst = new[] { "Jon", "Arya", "Sansa", "Bran" };
            var addToSecond = new[] { "Sansa", "Jon", "Arya" };
            var secondSet = new Set<string>();
            foreach (var cell in addToFirst)
            {
                stringSet.Add(cell);
            }
            foreach (var cell in addToSecond)
            {
                secondSet.Add(cell);
            }
            Assert.IsTrue(stringSet.IsSupersetOf(secondSet));
            secondSet.Remove("Arya");
            Assert.IsTrue(stringSet.IsSupersetOf(secondSet));
        }

        [TestMethod]
        public void OverlapsIntTest()
        {
            var addToFirst = new[] { 3, 4, 5, 6, 7, 8 };
            var addToSecond = new[] { 0, 4, 9 };
            var secondSet = new Set<int>();
            foreach (var cell in addToFirst)
            {
                intSet.Add(cell);
            }
            foreach (var cell in addToSecond)
            {
                secondSet.Add(cell);
            }
            Assert.IsTrue(intSet.Overlaps(secondSet));
            secondSet.Remove(4);
            Assert.IsFalse(intSet.Overlaps(secondSet));
        }

        [TestMethod]
        public void OverlapsStringTest()
        {
            var addToFirst = new[] { "Jon", "Arya", "Sansa", "Bran" };
            var addToSecond = new[] { "Sansa", "Daenerys" };
            var secondSet = new Set<string>();
            foreach (var cell in addToFirst)
            {
                stringSet.Add(cell);
            }
            foreach (var cell in addToSecond)
            {
                secondSet.Add(cell);
            }
            Assert.IsTrue(stringSet.Overlaps(secondSet));
            secondSet.Remove("Sansa");
            Assert.IsFalse(stringSet.Overlaps(secondSet));
        }

        [TestMethod]
        public void RemoveIntTest()
        {
            intSet.Add(141);
            Assert.IsTrue(intSet.Contains(141));
            intSet.Remove(141);
            Assert.IsFalse(intSet.Contains(141));
        }

        [TestMethod]
        public void RemoveStringTest()
        {
            stringSet.Add("Ebombe!");
            Assert.IsTrue(stringSet.Contains("Ebombe!"));
            stringSet.Remove("Ebombe!");
            Assert.IsFalse(stringSet.Contains("Ebombe!"));
        }

        [TestMethod]
        public void SetEqualsIntTest()
        {
            var addToFirst = new[] { 4, 8, 15, 16, 23, 42};
            var addToSecond = new[] { 15, 15, 4, 42, 8, 16, 23};
            var secondSet = new Set<int>();
            foreach (var cell in addToFirst)
            {
                intSet.Add(cell);
            }
            foreach (var cell in addToSecond)
            {
                secondSet.Add(cell);
            }
            Assert.IsTrue(intSet.SetEquals(secondSet));
        }

        [TestMethod]
        public void SetEqualsStringTest()
        {
            var addToFirst = new[] { "ten", "eleven", "ten"};
            var addToSecond = new[] { "ten", "eleven" };
            var secondSet = new Set<string>();
            foreach (var cell in addToFirst)
            {
                stringSet.Add(cell);
            }
            foreach (var cell in addToSecond)
            {
                secondSet.Add(cell);
            }
            Assert.IsTrue(stringSet.SetEquals(secondSet));
        }

        [TestMethod]
        public void SymmetricExceptWithIntTest()
        {
            var addToFirst = new[] { 4, 8, 15, 10, 11, 12 };
            var addToSecond = new[] { 10, 11, 12, 16, 23, 42 };
            var result = new[] { 4, 8, 15, 16, 23, 42 };
            var secondSet = new Set<int>();
            foreach (var cell in addToFirst)
            {
                intSet.Add(cell);
            }
            foreach (var cell in addToSecond)
            {
                secondSet.Add(cell);
            }
            intSet.SymmetricExceptWith(secondSet);
            IntAssertion(result);
        }


        [TestMethod]
        public void SymmetricExceptWithStringTest()
        {
            var addToFirst = new[] { "Jon", "Arya", "Sansa", "Bran" };
            var addToSecond = new[] { "Sansa", "Jon", "Arya", "Ned" };
            var result = new[] { "Bran", "Ned" };
            var secondSet = new Set<string>();
            foreach (var cell in addToFirst)
            {
                stringSet.Add(cell);
            }
            foreach (var cell in addToSecond)
            {
                secondSet.Add(cell);
            }
            stringSet.SymmetricExceptWith(secondSet);
            StringAssertion(result);
        }

        [TestMethod]
        public void UnionWithIntTest()
        {
            var addToFirst = new[] { 4, 8, 15, 16 };
            var addToSecond = new[] { 23, 42 };
            var result = new[] { 4, 8, 15, 16, 23, 42 };
            var secondSet = new Set<int>();
            foreach (var cell in addToFirst)
            {
                intSet.Add(cell);
            }
            foreach (var cell in addToSecond)
            {
                secondSet.Add(cell);
            }
            intSet.UnionWith(secondSet);
            IntAssertion(result);
        }

        [TestMethod]
        public void UnionWithStringTest()
        {
            var addToFirst = new[] { "Jon", "Arya" };
            var addToSecond = new[] { "Ned" };
            var result = new[] { "Jon", "Arya", "Ned" };
            var secondSet = new Set<string>();
            foreach (var cell in addToFirst)
            {
                stringSet.Add(cell);
            }
            foreach (var cell in addToSecond)
            {
                secondSet.Add(cell);
            }
            stringSet.SymmetricExceptWith(secondSet);
            StringAssertion(result);
        }

        private void IntAssertion(int[] result)
        {
            var index = 0;
            foreach (var cell in intSet)
            {
                Assert.AreEqual(result[index], cell);
                ++index;
            }
        }
        private void StringAssertion(string[] result)
        {
            var index = 0;
            foreach (var cell in stringSet)
            {
                Assert.AreEqual(result[index], cell);
                ++index;
            }
        }
    }
}
