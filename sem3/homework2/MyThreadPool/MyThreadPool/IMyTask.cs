using System;

namespace MyThreadPool
{
    /// <summary>
    /// IMyTask - task MyThreadPool should do
    /// </summary>
    public interface IMyTask<TResult>
    {
        bool IsCompleted { get; }

        TResult Result { get; }

        IMyTask<TNewResult> ContinueWith<TNewResult>(Func<TResult, TNewResult> function);
    }
}
