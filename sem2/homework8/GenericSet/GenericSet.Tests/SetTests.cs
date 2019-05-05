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
            var toAdd = new[] { 0, 1, 2, 3, 4, 5 };
            var toAddToOther = new[] { 3, 4, 5, 6, 7, 8 };
            var result = new[] { 0, 1, 2 };
            var other = new Set<int>();
            for (var i = 0; i < 6; ++i)
            {
                intSet.Add(toAdd[i]);
                other.Add(toAddToOther[i]);
            }
            intSet.ExceptWith(other);
            IntAssertion(result);
            Assert.AreEqual(3, intSet.Count);
        }

        [TestMethod]
        public void ExceptWithStringTest()
        {
            var toAdd = new[] { "Tony", "Steve", "Natasha", "Bruce" };
            var toAddToOther = new[] { "Vision", "Tony", "Natasha", "Stan" };
            var result = new[] { "Steve", "Bruce" };
            var other = new Set<string>();
            for (var i = 0; i < 4; ++i)
            {
                stringSet.Add(toAdd[i]);
                other.Add(toAddToOther[i]);
            }
            stringSet.ExceptWith(other);
            StringAssertion(result);
            Assert.AreEqual(2, stringSet.Count);
        }

        [TestMethod]
        public void IntersectWithIntTest()
        {
            var toAdd = new[] { 0, 1, 2, 3, 4, 5 };
            var toAddToOther = new[] { 3, 4, 5, 6, 7, 8 };
            var result = new[] { 3, 4, 5 };
            var other = new Set<int>();
            for (var i = 0; i < 6; ++i)
            {
                intSet.Add(toAdd[i]);
                other.Add(toAddToOther[i]);
            }
            intSet.IntersectWith(other);
            IntAssertion(result);
            Assert.AreEqual(3, intSet.Count);
        }

        [TestMethod]
        public void IntersectWithStringTest()
        {
            var toAdd = new[] { "Tony", "Steve", "Natasha", "Bruce" };
            var toAddToOther = new[] { "Vision", "Tony", "Natasha", "Stan" };
            var result = new[] { "Tony", "Natasha" };
            var other = new Set<string>();
            for (var i = 0; i < 4; ++i)
            {
                stringSet.Add(toAdd[i]);
                other.Add(toAddToOther[i]);
            }
            stringSet.IntersectWith(other);
            StringAssertion(result);
            Assert.AreEqual(2, stringSet.Count);
        }

        [TestMethod]
        public void IsProperSubsetOfIntTest()
        {
            var toAdd = new[] { 3, 4, 5 };
            var toAddToOther = new[] { 3, 4, 5, 6};
            var other = new Set<int>();
            foreach (var cell in toAdd)
            {
                intSet.Add(cell);
            }
            foreach (var cell in toAddToOther)
            {
                other.Add(cell);
            }
            Assert.IsTrue(intSet.IsProperSubsetOf(other));
            other.Remove(6);
            Assert.IsFalse(intSet.IsProperSubsetOf(other));
        }

        [TestMethod]
        public void IsProperSubsetOfStringTest()
        {
            var toAdd = new[] { "Jon", "Arya", "Sansa" };
            var toAddToOther = new[] { "Jon", "Arya", "Sansa", "Bran" };
            var other = new Set<string>();
            foreach (var cell in toAdd)
            {
                stringSet.Add(cell);
            }
            foreach (var cell in toAddToOther)
            {
                other.Add(cell);
            }
            Assert.IsTrue(stringSet.IsProperSubsetOf(other));
            other.Remove("Bran");
            Assert.IsFalse(stringSet.IsProperSubsetOf(other));
        }

        [TestMethod]
        public void IsProperSupersetOfIntTest()
        {
            var toAdd = new[] { 3, 4, 5, 6 };
            var toAddToOther = new[] { 3, 4, 5 };
            var other = new Set<int>();
            foreach (var cell in toAdd)
            {
                intSet.Add(cell);
            }
            foreach (var cell in toAddToOther)
            {
                other.Add(cell);
            }
            Assert.IsTrue(intSet.IsProperSupersetOf(other));
            intSet.Remove(6);
            Assert.IsFalse(intSet.IsProperSupersetOf(other));
        }

        [TestMethod]
        public void IsProperSupersetOfStringTest()
        {
            var toAdd = new[] { "Jon", "Arya", "Sansa", "Bran" };
            var toAddToOther = new[] { "Jon", "Arya", "Sansa" };
            var other = new Set<string>();
            foreach (var cell in toAdd)
            {
                stringSet.Add(cell);
            }
            foreach (var cell in toAddToOther)
            {
                other.Add(cell);
            }
            Assert.IsTrue(stringSet.IsProperSupersetOf(other));
            stringSet.Remove("Bran");
            Assert.IsFalse(stringSet.IsProperSupersetOf(other));
        }

        [TestMethod]
        public void IsSubsetOfIntTest()
        {
            var toAdd = new[] { 5, 4, 3 };
            var toAddToOther = new[] { 3, 4, 5, 6, 7, 8 };
            var other = new Set<int>();
            foreach (var cell in toAdd)
            {
                intSet.Add(cell);
            }
            foreach (var cell in toAddToOther)
            {
                other.Add(cell);
            }
            Assert.IsTrue(intSet.IsSubsetOf(other));
            intSet.Remove(4);
            Assert.IsTrue(intSet.IsSubsetOf(other));
        }

        [TestMethod]
        public void IsSubsetOfStringTest()
        {
            var toAdd = new[] { "Sansa", "Jon", "Arya"};
            var toAddToOther = new[] { "Jon", "Arya", "Sansa", "Bran" };
            var other = new Set<string>();
            foreach (var cell in toAdd)
            {
                stringSet.Add(cell);
            }
            foreach (var cell in toAddToOther)
            {
                other.Add(cell);
            }
            Assert.IsTrue(stringSet.IsSubsetOf(other));
            stringSet.Remove("Arya");
            Assert.IsTrue(stringSet.IsSubsetOf(other));
        }

        [TestMethod]
        public void IsSupersetOfIntTest()
        {
            var toAdd = new[] { 3, 4, 5, 6, 7, 8 };
            var toAddToOther = new[] { 4, 5, 3 };
            var other = new Set<int>();
            foreach (var cell in toAdd)
            {
                intSet.Add(cell);
            }
            foreach (var cell in toAddToOther)
            {
                other.Add(cell);
            }
            Assert.IsTrue(intSet.IsSupersetOf(other));
            other.Remove(4);
            Assert.IsTrue(intSet.IsSupersetOf(other));
        }

        [TestMethod]
        public void IsSupersetOfStringTest()
        {
            var toAdd = new[] { "Jon", "Arya", "Sansa", "Bran" };
            var toAddToOther = new[] { "Sansa", "Jon", "Arya" };
            var other = new Set<string>();
            foreach (var cell in toAdd)
            {
                stringSet.Add(cell);
            }
            foreach (var cell in toAddToOther)
            {
                other.Add(cell);
            }
            Assert.IsTrue(stringSet.IsSupersetOf(other));
            other.Remove("Arya");
            Assert.IsTrue(stringSet.IsSupersetOf(other));
        }

        [TestMethod]
        public void OverlapsIntTest()
        {
            var toAdd = new[] { 3, 4, 5, 6, 7, 8 };
            var toAddToOther = new[] { 0, 4, 9};
            var other = new Set<int>();
            foreach (var cell in toAdd)
            {
                intSet.Add(cell);
            }
            foreach (var cell in toAddToOther)
            {
                other.Add(cell);
            }
            Assert.IsTrue(intSet.Overlaps(other));
            other.Remove(4);
            Assert.IsFalse(intSet.Overlaps(other));
        }

        [TestMethod]
        public void OverlapsStringTest()
        {
            var toAdd = new[] { "Jon", "Arya", "Sansa", "Bran" };
            var toAddToOther = new[] { "Sansa", "Daenerys" };
            var other = new Set<string>();
            foreach (var cell in toAdd)
            {
                stringSet.Add(cell);
            }
            foreach (var cell in toAddToOther)
            {
                other.Add(cell);
            }
            Assert.IsTrue(stringSet.Overlaps(other));
            other.Remove("Sansa");
            Assert.IsFalse(stringSet.Overlaps(other));
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
            var toAdd = new[] { 4, 8, 15, 16, 23, 42};
            var toAddToOther = new[] { 15, 15, 4, 42, 8, 16, 23};
            var other = new Set<int>();
            foreach (var cell in toAdd)
            {
                intSet.Add(cell);
            }
            foreach (var cell in toAddToOther)
            {
                other.Add(cell);
            }
            Assert.IsTrue(intSet.SetEquals(other));
        }

        [TestMethod]
        public void SetEqualsStringTest()
        {
            var toAdd = new[] { "ten", "eleven", "ten"};
            var toAddToOther = new[] { "ten", "eleven" };
            var other = new Set<string>();
            foreach (var cell in toAdd)
            {
                stringSet.Add(cell);
            }
            foreach (var cell in toAddToOther)
            {
                other.Add(cell);
            }
            Assert.IsTrue(stringSet.SetEquals(other));
        }

        [TestMethod]
        public void SymmetricExceptWithIntTest()
        {
            var toAdd = new[] { 4, 8, 15, 10, 11, 12 };
            var toAddToOther = new[] { 10, 11, 12, 16, 23, 42 };
            var result = new[] { 4, 8, 15, 16, 23, 42 };
            var other = new Set<int>();
            foreach (var cell in toAdd)
            {
                intSet.Add(cell);
            }
            foreach (var cell in toAddToOther)
            {
                other.Add(cell);
            }
            intSet.SymmetricExceptWith(other);
            IntAssertion(result);
        }


        [TestMethod]
        public void SymmetricExceptWithStringTest()
        {
            var toAdd = new[] { "Jon", "Arya", "Sansa", "Bran" };
            var toAddToOther = new[] { "Sansa", "Jon", "Arya", "Ned" };
            var result = new[] { "Bran", "Ned" };
            var other = new Set<string>();
            foreach (var cell in toAdd)
            {
                stringSet.Add(cell);
            }
            foreach (var cell in toAddToOther)
            {
                other.Add(cell);
            }
            stringSet.SymmetricExceptWith(other);
            StringAssertion(result);
        }

        [TestMethod]
        public void UnionWithIntTest()
        {
            var toAdd = new[] { 4, 8, 15, 16 };
            var toAddToOther = new[] { 23, 42 };
            var result = new[] { 4, 8, 15, 16, 23, 42 };
            var other = new Set<int>();
            foreach (var cell in toAdd)
            {
                intSet.Add(cell);
            }
            foreach (var cell in toAddToOther)
            {
                other.Add(cell);
            }
            intSet.UnionWith(other);
            IntAssertion(result);
        }

        [TestMethod]
        public void UnionWithStringTest()
        {
            var toAdd = new[] { "Jon", "Arya" };
            var toAddToOther = new[] { "Ned" };
            var result = new[] { "Jon", "Arya", "Ned" };
            var other = new Set<string>();
            foreach (var cell in toAdd)
            {
                stringSet.Add(cell);
            }
            foreach (var cell in toAddToOther)
            {
                other.Add(cell);
            }
            stringSet.SymmetricExceptWith(other);
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
