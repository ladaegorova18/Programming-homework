using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test1;

namespace Task1.Tests
{
    [TestClass]
    public class Tests
    {
        private PriorityQueue queue;

        [TestInitialize]
        public void Initialize()
        {
            queue = new PriorityQueue();
        }

        [TestMethod]
        [ExpectedException(typeof(EmptyQueueException))]
        public void DeletingFromEmptyQueueTest()
        {
            queue.Dequeue();
        }

        [TestMethod]
        public void AddingOneValueTest()
        {
            queue.Enqueue(1, 0);
            Assert.AreEqual(1, queue.Size);
        }

        [TestMethod]
        public void AddingAndDeletingTest()
        {
            queue.Enqueue(1, 0);
            queue.Dequeue();
            Assert.IsTrue(queue.IsEmpty());
        }

        [TestMethod]
        public void AddingWithPriorityTest()
        {
            var expectedArray = new int[] { 0, 7, 1, 2, 8 };
            queue.Enqueue(1, 1);
            queue.Enqueue(2, 1);
            queue.Enqueue(0, 2);
            queue.Enqueue(8, 0);
            queue.Enqueue(7, 2);
            Assertion(expectedArray, queue);
        }

        [TestMethod]
        public void AddingTwoValuesTest()
        {
            queue.Enqueue(8, 1);
            queue.Enqueue(7, 2);
            Assert.AreEqual(7, queue.Dequeue());
            Assert.AreEqual(8, queue.Dequeue());
        }

        [TestMethod]
        public void AddingWithNegativePriorityTest()
        {
            queue.Enqueue(3, -2);
            queue.Enqueue(8, -1);
            Assert.AreEqual(8, queue.Dequeue());
            Assert.AreEqual(3, queue.Dequeue());
        }

        [TestMethod]
        public void AddingWithZeroPriorityTest()
        {
            queue.Enqueue(9, 0);
            queue.Enqueue(5, 0);
            Assert.AreEqual(9, queue.Dequeue());
            Assert.AreEqual(5, queue.Dequeue());
        }

        [TestMethod]
        public void AddingWithDiffrentPriorityTest()
        {
            queue.Enqueue(1, -6);
            queue.Enqueue(2, 0);
            queue.Enqueue(3, 4);
            Assert.AreEqual(3, queue.Dequeue());
            Assert.AreEqual(2, queue.Dequeue());
            Assert.AreEqual(1, queue.Dequeue());
        }

        [TestMethod]
        public void AddingTheSameValueTest()
        {
            for (var i = 0; i < 10; ++i)
            {
                queue.Enqueue(1, 1);
            }
            Assert.AreEqual(10, queue.Size);
        }

        [TestMethod]
        public void AddingTenValuesTest()
        {
            var expectedArray = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            for (var i = 0; i < 10; ++i)
            {
                queue.Enqueue(i, i);
            }
            Assertion(expectedArray, queue);
        }

        private void Assertion(int[] array, PriorityQueue queue)
        {
            foreach (var cell in array)
            {
                Assert.AreEqual(cell, queue.Dequeue());
            }
        }
    }
}
