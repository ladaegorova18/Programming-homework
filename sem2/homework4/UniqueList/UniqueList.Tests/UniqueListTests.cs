using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lists.Tests
{
    [TestClass]
    public class UniqueListTests
    {
        private UniqueList test;
        private List list;

        [TestInitialize]
        public void Initialize()
        {
            test = new UniqueList();
            list = new List();
        }

        [TestMethod]
        public void AddTest()
        {
            test.Add("1", 0);
            Assert.IsFalse(test.IsEmpty());
        }

        [TestMethod]
        public void IsValueTest()
        {
            test.Add("2", 0);
            Assert.IsTrue(test.Exists("2"));
        }

        [TestMethod]
        public void DeleteTest()
        {
            test.Add("3", 0);
            Assert.IsTrue(test.Exists("3"));
            test.Remove(0);
            Assert.IsFalse(test.Exists("3"));
        }

        [TestMethod]
        [ExpectedException(typeof(AddingExistingNodeException))]
        public void AddExistingNodeTest()
        {
            test.Add("4", 0);
            Assert.IsTrue(test.Exists("4"));
            test.Add("4", 0);
        }

        [TestMethod]
        public void AddTwoElementsTest()
        {
            test.Add("5", 0);
            test.Add("6", 1);
            test.Remove(0);
            test.Remove(0);
            Assert.IsTrue(test.IsEmpty());
        }

        [TestMethod]
        [ExpectedException(typeof(RemovingNonexistentNodeException))]
        public void RemoveTest()
        {
            test.Remove(0);
        }

        [TestMethod]
        [ExpectedException(typeof(RemovingNonexistentNodeException))]
        public void DoubleRemoveTest()
        {
            test.Add("4", 0);
            test.Remove(0);
            test.Remove(0);
        }

        [TestMethod]
        public void AddToWrongPositionTest()
        {
            test.Add("ololo", 9);
            Assert.AreEqual(0, test.Size);
        }

        [TestMethod]
        public void AddOnZeroPositionTest()
        {
            for (var i = 0; i < 10; ++i)
            {
                test.Add(i.ToString(), 0);
            }
            for (var j = 0; j < 10; ++j)
            {
                Assert.AreEqual(j.ToString(), test.GetValue(9 - j));
            }
        }

        [TestMethod]
        public void AddOnIncreasingPositionTest()
        {
            for (var i = 0; i < 10; ++i)
            {
                test.Add(i.ToString(), i);
            }
            for (var j = 0; j < 10; ++j)
            {
                Assert.AreEqual(j.ToString(), test.GetValue(j));
            }
        }
    }
}
