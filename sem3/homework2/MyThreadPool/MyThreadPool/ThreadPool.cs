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
        private readonly AutoResetEvent available = new AutoResetEvent(false);
        private readonly AutoResetEvent waitMain = new AutoResetEvent(false);
        private readonly Thread[] threads;
        private readonly ConcurrentQueue<Action> tasksQueue = new ConcurrentQueue<Action>();
        private readonly CancellationTokenSource tokenSource;
        protected CancellationToken token { get; private set; }
        private object lockAdding = new object();

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
                                waitMain.Set();
                                return;
                            }
                            available.WaitOne();
                        }
                        tasksQueue.TryDequeue(out Action newAction);
                        newAction.Invoke();
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
                AddAction(task.Do);
                return task;
            }
            return null;
        }

        private void AddAction(Action action)
        {
            lock (lockAdding)
            {
                if (!token.IsCancellationRequested)
                {
                    tasksQueue.Enqueue(action);
                    available.Set();
                }
            }
        }

        /// <summary>
        /// stops all threads
        /// </summary>
        public void Shutdown()
        {
            lock (lockAdding)
            {
                tokenSource.Cancel();
                foreach (var thread in threads)
                {
                    available.Set();
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
                        while (localQueue.Count != 0 && !myThreadPool.token.IsCancellationRequested)
                        {
                            myThreadPool.AddAction(localQueue.Dequeue());
                        }
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
                localQueue.Enqueue(action);
                lock (locker)
                {
                    if (IsCompleted)
                    {
                        myThreadPool.AddAction(action);
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
