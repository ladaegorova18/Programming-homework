using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyThreadPoolTask.Tests
{
    [TestClass]
    public class MyThreadPoolTests
    {
        private MyThreadPool myThreadPool;
        private int n;
        private Random rnd = new Random();

        [TestInitialize]
        public void Initialize()
        {
            n = rnd.Next(4, 42);
            myThreadPool = new MyThreadPool(n);
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
            var threadsCount = System.Diagnostics.Process.GetCurrentProcess().Threads.Count;
            Assert.IsTrue(threadsCount >= n);
        }

        [TestMethod]
        public void ContinueWithTest()
        {
            Func<int> func = () => 5 - 2;
            Func<int, int> continueFunc = x => x * 4;
            var task = myThreadPool.QueueUserWorkItem(func);
            var continueTask = task.ContinueWith(continueFunc, myThreadPool);
            Assert.AreEqual(12, continueTask.Result);
            Assert.IsTrue(continueTask.IsCompleted);
        }

        [TestMethod]
        public void ShutdownTest()
        {
            Func<int> func = () => 2 * 3;
            var task = myThreadPool.QueueUserWorkItem(func);
            Assert.AreEqual(6, task.Result);
            var before = GetThreadsCount();
            myThreadPool.Shutdown();
            var after = GetThreadsCount();
            Assert.AreEqual(after, before - n + 1);
        }

        private static int GetThreadsCount() => System.Diagnostics.Process.GetCurrentProcess().Threads.Count;

        //[TestMethod]
        //public void ExceptionTest()
        //{
        //    Func<string> func = () => throw new InvalidOperationException("Invalid operation!");
        //    var task = myThreadPool.QueueUserWorkItem(func);
        //    Assert.ThrowsException<AggregateException>(task.Do);
        //}
    }
}
