using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LazyInterface.Tests
{
    [TestClass]
    public class LazyInterfaceTests
    {
        // one thread tests

        [TestMethod]
        public void OneThreadSimpleMethodTest()
        {
            var x = 0.1f;

            float Simple() => x;

            Func<float> simple = Simple;
            var lazy = LazyFactory<float>.CreateOneThreading(simple);
            Assert.AreEqual(x, lazy.Get());
        }

        [TestMethod]
        public void OneThreadPowTest()
        {
            Func<double> addition = delegate()
            {
                return Math.Pow(2.0, 30.0);
            };

            var lazy = LazyFactory<double>.CreateOneThreading(addition);
            Assert.AreEqual(lazy.Get(), 1073741824.0);
        }

        [TestMethod]
        public void OneThreadNullTest()
        {
            string Empty() => null;

            Func<string> empty = Empty;
            var lazy = LazyFactory<string>.CreateOneThreading(empty);
            Assert.IsTrue(lazy.Get() == null);
        }

        [TestMethod]
        public void OneThreadExceptionTest()
        {
            int Exception() => throw new ArgumentException("this method throws an exception");

            Func<int> exception = Exception;
            var lazy = LazyFactory<int>.CreateOneThreading(exception);
            lazy.Get();
        }

        [TestMethod]
        public void OneThreadDivideByZeroTest()
        {
            int Divide()
            {
                var a = 5;
                var b = 0;
                return a / b;
            }

            Func<int> divide = Divide;
            var lazy = LazyFactory<int>.CreateOneThreading(divide);
            lazy.Get();
        }

        // multi thread tests

        [TestMethod]
        public void MultiThreadPowTest()
        {
            double Pow() => Math.Pow(2.0, 30.0);

            Func<double> pow = Pow;
            var lazyMultiThread = LazyFactory<double>.CreateMultiThreading(pow);

            var threads = new Thread[3];
            var results = new double[3];
            for (var i = 0; i < 3; i++)
            {
                threads[i] = new Thread(() =>
                {
                    results[i] = lazyMultiThread.Get();
                });
            }

            StartThreads(threads);

            Assert.AreEqual(results[0], results[1]);
            Assert.AreEqual(results[1], results[2]);
        }

        [TestMethod]
        public void MultiThreadStringWorkTest()
        {
            string Supplier()
            {
                return "doctor " + "who";
            }
            Func<string> supplier = Supplier;

            var lazyMultiThread = LazyFactory<string>.CreateMultiThreading(supplier);
            Assert.AreEqual("doctor who", lazyMultiThread.Get());
        }

        [TestMethod]
        public void MultiThreadListTest()
        {
            List<int> MakeList()
            {
                var list = new List<int>();
                list.Add(5);
                return list;
            }
            Func<List<int>> makeList = MakeList;

            var lazyMultiThread = LazyFactory<List<int>>.CreateMultiThreading(makeList);
            var threads = new Thread[3];
            var results = new List<int>[3];
            for (var i = 0; i < 3; i++)
            {
                threads[i] = new Thread(() =>
                {
                    results[i] = lazyMultiThread.Get();
                });
            }

            StartThreads(threads);

            Assert.AreEqual(results[0], results[1]);
            Assert.AreEqual(results[1], results[2]);
        }

        [TestMethod]
        public void MultiThreadArrayTest()
        {
            int[] MakeArray()
            {
                var array = new int[3];
                array[0] = 10;
                return array;
            }

            Func<int[]> makeArray = MakeArray;
            var lazyMultiThread = LazyFactory<int[]>.CreateMultiThreading(makeArray);

            var threads = new Thread[3];
            var results = new int[3][];
            for (var i = 0; i < 3; i++)
            {
                threads[i] = new Thread(() =>
                {
                    results[i] = lazyMultiThread.Get();
                });
            }

            StartThreads(threads);

            Assert.AreEqual(results[0], results[1]);
            Assert.AreEqual(results[1], results[2]);
        }

        private static void StartThreads(Thread[] threads)
        {
            foreach (var thread in threads)
            {
                thread.Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }
        }
    }
}
