using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LazyInterface.Tests
{
    [TestClass]
    public class LazyInterfaceTests
    {
        // one thread tests

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
            int Exception() => throw new ArgumentException();

            Func<int> exception = Exception;
            var lazy = LazyFactory<int>.CreateOneThreading(exception);
            lazy.Get();
        }

        // multi thread tests

        [TestMethod]
        public void MultiThreadPowTest()
        {
            double Hello() => Math.Pow(2.0, 30.0);

            Func<double> hello = Hello;
            double secondResult = 0;
            double thirdResult = 0;
            var lazyMultiThread = LazyFactory<double>.CreateMultiThreading(hello);

            var secondThread = new Thread(() =>
            {
                secondResult = lazyMultiThread.Get();
            });

            var thirdThread = new Thread(() =>
            {
                thirdResult = lazyMultiThread.Get();
            });

            secondThread.Start();
            thirdThread.Start();
            var firstResult = lazyMultiThread.Get();
            Assert.AreEqual(firstResult, secondResult);
            Assert.AreEqual(secondResult, thirdResult);
        }

        [TestMethod]
        public void MultiThreadStringTest()
        {
            string Hello() => "doctor" + "who";

            Func<string> hello = Hello;
            string secondResult = null;
            string thirdResult = null;
            var lazyMultiThread = LazyFactory<string>.CreateMultiThreading(hello);

            var secondThread = new Thread(() =>
            {
                secondResult = lazyMultiThread.Get();
            });

            var thirdThread = new Thread(() =>
            {
                thirdResult = lazyMultiThread.Get();
            });

            secondThread.Start();
            thirdThread.Start();
            var firstResult = lazyMultiThread.Get();
            Assert.AreEqual(firstResult, secondResult);
            Assert.AreEqual(secondResult, thirdResult);
        }
    }
}
