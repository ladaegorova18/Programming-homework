using System;
using System.Collections.Generic;
using System.Threading;

namespace MyThreadPoolTask
{
    /// <summary>
    /// MyThreadPool - tool to do tasks
    /// </summary>
    public class MyThreadPool<TResult>
    {
        private readonly AutoResetEvent available = new AutoResetEvent(true);
        private Thread[] threads;
        private Queue<MyTask<TResult>> tasksQueue = new Queue<MyTask<TResult>>();
        private CancellationTokenSource tokenSource = new CancellationTokenSource();
        private CancellationToken token = new CancellationToken();

        /// <summary>
        /// thread pool constructor
        /// </summary>
        /// <param name="n"> count of threads </param>
        public MyThreadPool(int n)
        {
            threads = new Thread[n];
            for (var i = 0; i < n; ++i)
            {
                threads[i] = new Thread(() =>
                {
                    if (tasksQueue.Count == 0)
                    {
                        available.WaitOne();
                    }
                    DoTask();
                });
                threads[i].Start();
            }
        }

        private void DoTask()
        {
            if (tasksQueue.Count == 0)
            {
                return;
            }
            var task = tasksQueue.Dequeue();
            if (!task.IsCompleted)
            {
                try
                {
                    task.Result = task.Function();
                    task.Function = null;
                }
                catch (Exception innerException)
                {
                    throw new AggregateException(innerException);
                }
                finally
                {
                    task.IsCompleted = true;
                }
            }
        }

        /// <summary>
        /// adds task to queue
        /// </summary>
        /// <param name="task"> task to add </param>
        public void QueueUserWorkItem(MyTask<TResult> task)
        {
            if (!token.IsCancellationRequested)
            {
                tasksQueue.Enqueue(task);
                available.Set();
            }
        }
    }
}
