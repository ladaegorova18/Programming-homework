using System;

namespace MyThreadPoolTask
{
    /// <summary>
    /// IMyTask - task MyThreadPool should do
    /// </summary>
    public interface IMyTask<TResult>
    {
        bool IsCompleted { get; }

        TResult Result { get; }

        MyTask<TResult> ContinueWith(Func<TResult, TResult> function, MyThreadPool myThreadPool);
    }
}
