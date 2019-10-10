using System;
using System.Threading;

namespace MyThreadPoolTask
{
    /// <summary>
    /// task that MyThreadPool should do
    /// </summary>
    public class MyTask<TResult> : IMyTask<TResult>
    {
        /// <summary>
        /// checks if result is ready
        /// </summary>
        public bool IsCompleted { get; set; } = false;

        private ManualResetEvent available = new ManualResetEvent(true);
        private Func<TResult> function;
        private TResult result;

        /// <summary>
        /// MyTask result
        /// </summary>
        public TResult Result
        {
            get
            {
                while (true)
                {
                    if (!IsCompleted)
                    {
                        available.WaitOne();
                    }
                    else
                    {
                        return result;
                    }
                }
            }
            private set { }
        }

        /// <summary>
        /// MyTask constructor
        /// </summary>
        /// <param name="function"> count function </param>
        public MyTask(Func<TResult> function) => this.function = function;

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
                throw new AggregateException(innerException);
            }
            IsCompleted = true;
            available.Set();
        }

        public MyTask<TResult> ContinueWith(Func<TResult, TResult> function, MyThreadPool myThreadPool)
        {
            Func<TResult> func = () => function(Result);
            var newTask = myThreadPool.QueueUserWorkItem(func);
            return newTask;
        }
    }
}
