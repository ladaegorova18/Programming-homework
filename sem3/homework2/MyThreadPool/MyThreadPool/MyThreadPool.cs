using System;
using System.Threading;
using System.Collections.Concurrent;

namespace MyThreadPoolTask
{
    /// <summary>
    /// MyThreadPool - tool to do tasks
    /// </summary>
    public class MyThreadPool
    {
        private static readonly AutoResetEvent available = new AutoResetEvent(true);
        private static Thread[] threads;
        private ConcurrentQueue<Action> tasksQueue = new ConcurrentQueue<Action>();
        private CancellationTokenSource tokenSource;
        private CancellationToken token;

        /// <summary>
        /// thread pool constructor
        /// </summary>
        /// <param name="n"> count of threads </param>
        public MyThreadPool(int n)
        {
            tokenSource = new CancellationTokenSource();
            token = tokenSource.Token;
            threads = new Thread[n];
            for (var i = 0; i < n; ++i)
            {
                threads[i] = new Thread(() =>
                {
                    while (tasksQueue.Count != 0 || !token.IsCancellationRequested)
                    {
                        if (tasksQueue.Count != 0)
                        {
                            DoTask();
                        }
                        available.WaitOne();
                    }
                    if (token.IsCancellationRequested)
                    {
                        return;
                    }
                });
                threads[i].Start();
            }   
        }

        private void DoTask()
        {
            tasksQueue.TryDequeue(out Action task);
            task.Invoke();
        }

        /// <summary>
        /// adds task to queue
        /// </summary>
        /// <param name="task"> task to add </param>
        public MyTask<TResult> QueueUserWorkItem<TResult>(Func<TResult> func)
        {
            var task = new MyTask<TResult>(func);
            if (!token.IsCancellationRequested)
            {
                var action = new Action(task.Do);
                tasksQueue.Enqueue(action);
                available.Set();
            }
            return task;
        }

        /// <summary>
        /// stops all threads
        /// </summary>
        public void Shutdown()
        {
            tokenSource.Cancel();
            for (var i = 0; i < threads.Length; ++i)
            {
                available.Set();
            }
            Thread.Sleep(4000);
        }
    }
}
