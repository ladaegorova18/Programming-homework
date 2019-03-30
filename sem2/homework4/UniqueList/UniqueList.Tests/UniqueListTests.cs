using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lists.Tests
{
    [TestClass]
    public class UniqueListTests
    {
        [TestInitialize]
        public void Initialize()
        {
            test = new UniqueList();
            list = new List();
        }

        [TestCleanup]
        public void Clear()
        {
            test.Clear();
            list.Clear();
        }

        [TestMethod]
        public void AddTest()
        {
            test.Add("1");
            Assert.IsFalse(test.IsEmpty());
        }

        [TestMethod]
        public void IsValueTest()
        {
            test.Add("2");
            Assert.IsTrue(test.IsValue("2"));
        }

        [TestMethod]
        public void DeleteTest()
        {
            test.Add("3");
            Assert.IsTrue(test.IsValue("3"));
            test.Remove("3");
            Assert.IsFalse(test.IsValue("3"));
        }

        [TestMethod]
        [ExpectedException(typeof(AddingExistingNodeException))]
        public void AddExistingNodeTest()
        {
            test.Add("4");
            Assert.IsTrue(test.IsValue("4"));
            test.Add("4");
            test.Add("4");
        }

        [TestMethod]
        public void AddTwoElementsTest()
        {
            test.Add("5");
            test.Add("6");
            test.Remove("5");
            test.Remove("6");
            Assert.IsTrue(test.IsEmpty());
        }

        [TestMethod]
        [ExpectedException(typeof(RemovingNonexistentNodeException))]
        public void RemoveTest()
        {
            test.Remove("7");
        }

        [TestMethod]
        public void CallMenuTest()
        {
            var menu = new Menu();
        }

        [TestMethod]
        public void RemoveRepeatingTest()
        {
            for (int i = 0; i < 10; ++i)
            {
                list.Add("1");
            }
            test = new UniqueList(list);
            Assert.IsTrue(test.Size == 1);
        }

        [TestMethod]
        [ExpectedException(typeof(RemovingNonexistentNodeException))]
        public void DoubleRemoveTest()
        {
            test.Add("4");
            test.Remove("4");
            test.Remove("4");
        }

        [TestMethod]
        public void FromOneToFiveListTest()
        {
            for (int i = 1; i <= 5; ++i)
            {
                list.Add(i.ToString());
            }
            for (int j = 5; j > 0; --j)
            {
                list.Add(j.ToString());
            }
            test = new UniqueList(list);
            for (int i = 1; i <= 5; ++i)
            {
                Assert.IsTrue(test.IsValue(i.ToString()));
            }
        }

        [TestMethod]
        public void SomeRepeatingElementsTest()
        {
            string[] array = { "3", "4", "5", "5", "8", "4", "1" };
            string[] result = { "3", "4", "5", "8", "1" };
            foreach (var i in array)
            {
                list.Add(i);
            }
            test = new UniqueList(list);
            var temp = test.Head;
            foreach (var i in result)
            {
                Assert.AreEqual(temp.Value, i);
                temp = temp.Next;
            }
        }

        [TestMethod]
        public void ZeroesListTest()
        {
            for (int i = 0; i < 10; ++i)
            {
                list.Add(0.ToString());
            }
            test = new UniqueList(list);
            Assert.AreEqual(1, test.Size);
        }

        [TestMethod]
        public void OneElementTest()
        {
            list.Add("8");
            test = new UniqueList(list);
            Assert.AreEqual(1, test.Size);
        }

        [TestMethod]
        public void EmptyListTest()
        {
            test = new UniqueList(list);
            Assert.IsTrue(test.IsEmpty());
        }

        [TestMethod]
        public void DiffrentValuesListTest()
        {
            for (int i = 0; i < 10; ++i)
            {
                list.Add(i.ToString());
            }
            test = new UniqueList(list);
            Assert.AreEqual(10, test.Size);
        }

        private UniqueList test;
        private List list;
    }
}
