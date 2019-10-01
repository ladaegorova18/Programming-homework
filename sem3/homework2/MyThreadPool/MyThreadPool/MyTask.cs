using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyThreadPoolTask
{
    /// <summary>
    /// 
    /// </summary>
    public class MyTask<TResult> : IMyTask<TResult>
    {
        /// <summary>
        /// checks if result is ready
        /// </summary>
        public bool IsCompleted { get; set; } = false;

        private ManualResetEvent available = new ManualResetEvent(true);

        /// <summary>
        /// MyTask result
        /// </summary>
        public TResult Result
        {
            get
            {
                if (!IsCompleted)
                {
                    available.WaitOne();
                }
                return Result;
            }
            set
            {
                Result = value;
                available.Set();
                return;
            }
        }

        /// <summary>
        /// counts result
        /// </summary>
        public Func<TResult> Function { get; set; }

        /// <summary>
        /// MyTask constructor
        /// </summary>
        /// <param name="function"> count function </param>
        public MyTask(Func<TResult> function)
        {
            Function = function;
        }

        public MyTask<TResult> ContinueWith(Func<TResult, TResult> function) => new MyTask<TResult>(() => function(Result));
    }
}
