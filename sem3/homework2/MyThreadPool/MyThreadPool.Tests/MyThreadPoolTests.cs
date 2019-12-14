using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyThreadPool.Tests
{
    [TestClass]
    public class MyThreadPoolTests
    {
        private ThreadPool myThreadPool;
        private int n;
        private readonly Random rnd = new Random();

        [TestInitialize]
        public void Initialize()
        {
            n = rnd.Next(4, 42);
            myThreadPool = new ThreadPool(n);
        }
        
        [TestMethod]
        public void SimpleWorkTest()
        {
            Func<int> func = () => 2 * 3;
            var task = myThreadPool.QueueUserWorkItem(func);
            Assert.AreEqual(6, task.Result);
            Assert.IsTrue(task.IsCompleted);
        }

        [TestMethod]
        public void CountThreadsTest()
        {
            Assert.IsTrue(myThreadPool.ThreadsCount >= n);
        }

        [TestMethod]
        public void ContinueWithTest()
        {
            Func<int> func = () => 5 - 2;
            Func<int, int> continueFunc = x => x * 4;
            var task = myThreadPool.QueueUserWorkItem(func);
            var continueTask = task.ContinueWith(continueFunc);
            Assert.AreEqual(12, continueTask.Result);
            Assert.IsTrue(continueTask.IsCompleted);
        }

        [TestMethod]
        public void ShutdownTest()
        {
            myThreadPool = new ThreadPool(10);
            Func<double> func = () => Math.Pow(2, 30);
            myThreadPool.QueueUserWorkItem(func);
            myThreadPool.Shutdown();
            Assert.AreEqual(0, myThreadPool.ThreadsCount);
        }

        [TestMethod]
        public void ExceptionTest()
        {
            Func<string> func = () => throw new InvalidOperationException("Invalid operation!");
            var task = myThreadPool.QueueUserWorkItem(func);
            Func<string> result = () => task.Result;
            Assert.ThrowsException<AggregateException>(result);
        }

        [TestMethod]
        public void ParallelTest()
        {
            var result = 0;
            for (var i = 0; i < n; ++i)
            {
                myThreadPool.QueueUserWorkItem(() =>
                {
                    ++result;
                    Thread.Sleep(200);
                    return 0;
                });
            }
            Thread.Sleep(100);
            myThreadPool.Shutdown();
            Assert.AreEqual(n, result);
        }
    }
}
