using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyThreadPoolTask.Tests
{
    [TestClass]
    public class MyThreadPoolTests
    {
        [TestMethod]
        public void SimpleWorkTest()
        {
            var myThreadPool = new MyThreadPool<int>(3);
            var task = new MyTask<int>(() => 2 * 3);
            myThreadPool.QueueUserWorkItem(task);
            Assert.AreEqual(6, task.Result);
            Assert.IsTrue(task.IsCompleted);
        }
    }
}
