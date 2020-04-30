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
            Func<float> simple = () => 0.1f;
            var lazy = LazyFactory<float>.CreateOneThreading(simple);
            Assert.AreEqual(0.1f, lazy.Get());
        }

        [TestMethod]
        public void OneThreadPowTest()
        {
            Func<double> addition = () =>
            {
                return Math.Pow(2.0, 30.0);
            };
            var lazy = LazyFactory<double>.CreateOneThreading(addition);
            Assert.AreEqual(lazy.Get(), 1073741824.0);
        }

        [TestMethod]
        public void OneThreadNullTest()
        {
            Func<string> empty = () => null;
            var lazy = LazyFactory<string>.CreateOneThreading(empty);
            Assert.IsNull(lazy.Get());
        }

        [TestMethod]
        public void OneThreadNullMethodTest()
        {
            var lazy = LazyFactory<string>.CreateOneThreading(null);
            Assert.ThrowsException<NullReferenceException>(lazy.Get);
        }

        [TestMethod]
        public void OneThreadExceptionTest()
        {
            Func<string> exception = () => throw new ArgumentException("this method throws an exception");
            var lazy = LazyFactory<string>.CreateOneThreading(exception);
            Assert.ThrowsException<ArgumentException>(lazy.Get);
        }

        [TestMethod]
        public void OneThreadDivideByZeroTest()
        {
            Func<string> divide = () =>
            {
                var a = 5;
                var b = 0;
                if (b == 0)
                {
                    throw new DivideByZeroException();
                }
                return (a / b).ToString();
            };
            var lazy = LazyFactory<string>.CreateOneThreading(divide);
            Assert.ThrowsException<DivideByZeroException>(lazy.Get);
        }

        // multi thread tests

        [TestMethod]
        public void MultiThreadPowTest()
        {
            Func<double> pow = () => Math.Pow(2.0, 30.0);
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

            Assert.AreEqual(0, results[0].CompareTo(results[1]));
            Assert.AreEqual(0, results[1].CompareTo(results[2]));
        }

        [TestMethod]
        public void MultiThreadStringWorkTest()
        {
            Func<string> supplier = () =>
            {
                return "doctor " + "who";
            };
            var lazyMultiThread = LazyFactory<string>.CreateMultiThreading(supplier);
            Assert.AreEqual("doctor who", lazyMultiThread.Get());
        }

        [TestMethod]
        public void MultiThreadListTest()
        {
            Func<List<int>> makeList = () =>
            {
                var list = new List<int>();
                list.Add(5);
                return list;
            };
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
            Func<int[]> makeArray = () =>
            {
                var array = new int[3];
                array[0] = 10;
                return array;
            };
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
