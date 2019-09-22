using System;
using System.Threading;

namespace LazyInterface
{
    /// <summary>
    /// lazy multi-thread counter
    /// </summary>
    public class LazyMultiThread<T> : ILazy<T>
    {
        private readonly Func<T> function;
        private volatile bool counted = false;
        private T result = default(T);
        private readonly object locker = new object();

        /// <summary>
        /// constructor for lazy multi-thread counter
        /// </summary>
        /// <param name="function"> count method </param>
        public LazyMultiThread(Func<T> function)
        {
            this.function = function;
        }

        /// <summary>
        /// returns result
        /// </summary>
        public T Get()
        {
            if (!counted)
            {
                lock (locker)
                {
                    if (counted)
                    {
                        return result;
                    }
                    result = function();
                    counted = true;
                }
            }
            return result;
        }
    }
}
