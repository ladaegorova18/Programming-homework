using System;

namespace MyThreadPoolTask
{
    /// <summary>
    /// IMyTask - task MyThreadPool should do
    /// </summary>
    public interface IMyTask<TResult>
    {
        bool IsCompleted { get; set; }

        TResult Result { get; set; }

        Func<TResult> Function { get; set; } 

        MyTask<TResult> ContinueWith(Func<TResult, TResult> function);
    }
}
