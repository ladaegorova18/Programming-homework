﻿using System;
using System.Threading;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace MyThreadPoolTask
{
    /// <summary>
    /// MyThreadPool - tool to do tasks
    /// </summary>
    public class MyThreadPool
    {
        private readonly AutoResetEvent available = new AutoResetEvent(false);
        private readonly AutoResetEvent waitMain = new AutoResetEvent(false);
        private Thread[] threads;
        private ConcurrentQueue<Action> tasksQueue = new ConcurrentQueue<Action>();
        private CancellationTokenSource tokenSource;
        private CancellationToken token;

        /// <summary>
        /// Amount of active threads
        /// </summary>
        public int ThreadsCount { get; private set; }   

        /// <summary>
        /// thread pool constructor
        /// </summary>
        /// <param name="n"> count of threads </param>
        public MyThreadPool(int n)
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
                        Action newAction = null;
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
                        tasksQueue.TryDequeue(out Action action);
                        newAction = action;
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
            tasksQueue.Enqueue(action);
            available.Set();
        }

        /// <summary>
        /// stops all threads
        /// </summary>
        public void Shutdown()
        {
            tokenSource.Cancel();
            foreach (var thread in threads)
            {
                available.Set();
                waitMain.WaitOne();
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

            private Queue<Action> localQueue = new Queue<Action>();
            private ManualResetEvent ready = new ManualResetEvent(false);
            private Func<TResult> function;
            private TResult result;
            private object locker = new object();
            private MyThreadPool myThreadPool;
            private AggregateException aggregateException = null;

            /// <summary>
            /// MyTask result
            /// </summary>
            public TResult Result
            {
                get
                {
                    while (true)
                    {
                        if (aggregateException != null)
                        {
                            throw aggregateException;
                        }
                        if (!IsCompleted)
                        {
                            ready.WaitOne();
                        }
                        else
                        {
                            return result;
                        }
                    }
                }
            }

            /// <summary>
            /// MyTask constructor
            /// </summary>
            /// <param name="function"> count function </param>
            public MyTask(Func<TResult> function, MyThreadPool myThreadPool)
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
                    IsCompleted = true;
                }
                catch (Exception innerException)
                {
                    aggregateException = new AggregateException(innerException);
                }
                finally
                {
                    ready.Set();
                    lock (locker)
                    {
                        while (localQueue.Count != 0)
                        {
                            myThreadPool.tasksQueue.Enqueue(localQueue.Dequeue());
                            myThreadPool.available.Set();
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
