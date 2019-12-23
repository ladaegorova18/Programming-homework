using System;
using System.Threading;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace MyThreadPool
{
    /// <summary>
    /// MyThreadPool - tool to do tasks
    /// </summary>
    public class ThreadPool
    {
        private readonly ManualResetEvent available = new ManualResetEvent(false);
        private readonly AutoResetEvent waitMain = new AutoResetEvent(false);
        private readonly Thread[] threads;
        private readonly ConcurrentQueue<Action> tasksQueue = new ConcurrentQueue<Action>();
        private readonly CancellationTokenSource tokenSource;
        private CancellationToken token;
        private readonly object locker = new object();

        /// <summary>
        /// Amount of active threads
        /// </summary>
        public int ThreadsCount { get; private set; }   

        /// <summary>
        /// thread pool constructor
        /// </summary>
        /// <param name="n"> count of threads </param>
        public ThreadPool(int n)
        {
            tokenSource = new CancellationTokenSource();
            token = tokenSource.Token;
            threads = new Thread[n];
            ThreadsCount = n;
            for (var i = 0; i < n; ++i)
            {
                threads[i] = new Thread(() =>
                {
                    while (true)
                    {
                        while (tasksQueue.IsEmpty)
                        {
                            if (token.IsCancellationRequested)
                            {
                                --ThreadsCount;
                                if (ThreadsCount == 0)
                                {
                                    while (!waitMain.Set())
                                    {
                                        Thread.Sleep(100);
                                    }
                                }
                                return;
                            }
                            available.WaitOne();
                        }
                        if (tasksQueue.TryDequeue(out Action newAction))
                        {
                            newAction.Invoke();
                        }
                    }
                });
                threads[i].Start();
            }
        }

        /// <summary>
        /// adds task to queue
        /// </summary>
        /// <param name="task"> task to add </param>
        public IMyTask<TResult> QueueUserWorkItem<TResult>(Func<TResult> func)
        {
            if (!token.IsCancellationRequested)
            {
                var task = new MyTask<TResult>(func, this);
                if (AddAction(task.Do))
                {
                    return task;
                }
            }
            return null;
        }

        private bool AddAction(Action action)
        {
            lock (locker)
            {
                if (!token.IsCancellationRequested)
                {
                    tasksQueue.Enqueue(action);
                    available.Set();
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// stops all threads
        /// </summary>
        public void Shutdown()
        {
            lock (locker)
            {
                tokenSource.Cancel();
                available.Set();
                if (ThreadsCount != 0)
                {
                    waitMain.WaitOne();
                }
            }
        }

        /// <summary>
        /// task that MyThreadPool should do
        /// </summary>
        private class MyTask<TResult> : IMyTask<TResult>
        {
            /// <summary>
            /// checks if result is ready
            /// </summary>
            public bool IsCompleted { get; private set; }

            private readonly Queue<Action> localQueue = new Queue<Action>();
            private readonly ManualResetEvent getResult = new ManualResetEvent(false);
            private Func<TResult> function;
            private TResult result;
            private readonly object locker = new object();
            private readonly ThreadPool myThreadPool;
            private AggregateException aggregateException = null;

            /// <summary>
            /// MyTask result
            /// </summary>
            public TResult Result
            {
                get
                {
                    if (!IsCompleted)
                    {
                        getResult.WaitOne();
                    }
                    if (aggregateException != null)
                    {
                        throw aggregateException;
                    }
                    return result;
                }
            }

            /// <summary>
            /// MyTask constructor
            /// </summary>
            /// <param name="function"> count function </param>
            public MyTask(Func<TResult> function, ThreadPool myThreadPool)
            {
                this.function = function;
                this.myThreadPool = myThreadPool;
            }

            /// <summary>
            /// do task method
            /// </summary>
            public void Do()
            {
                try
                {
                    result = function();
                    function = null;
                }
                catch (Exception innerException)
                {
                    aggregateException = new AggregateException(innerException);
                }
                finally
                {
                    IsCompleted = true;
                    getResult.Set();
                    lock (locker)
                    {
                        while (localQueue.Count != 0)
                        {
                            if (!myThreadPool.AddAction(localQueue.Dequeue()))
                            {
                                aggregateException = new AggregateException("Thread pool is stopped!");
                            }
                        }
                        IsCompleted = true;
                    }
                }
            }

            /// <summary>
            /// makes new task with function and result of base task
            /// </summary>
            /// <returns> new task </returns>
            public IMyTask<TNewResult> ContinueWith<TNewResult>(Func<TResult, TNewResult> function)
            {
                Func<TNewResult> func = () => function(Result);
                var newTask = new MyTask<TNewResult>(func, myThreadPool);
                var action = new Action(newTask.Do);
                lock (locker)
                {
                    if (IsCompleted)
                    {
                        if (!myThreadPool.AddAction(action))
                        {
                            aggregateException = new AggregateException("Thread pool is stopped!");
                        }
                    }
                    else
                    {
                        localQueue.Enqueue(action);
                    }
                }
                return newTask;
            }
        }
    }
}
