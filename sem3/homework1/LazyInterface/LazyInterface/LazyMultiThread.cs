using System;
using System.Threading;

namespace LazyInterface
{
    /// <summary>
    /// lazy multi-thread counter
    /// </summary>
    public class LazyMultiThread<T> : ILazy<T>
    {
        private Func<T> function;
        private bool counted = false;
        private T result = default(T);

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
            if (!Volatile.Read(ref counted))
            {
                try
                {
                    result = function();
                }
                catch(Exception e)
                {
                    result = default(T);
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Volatile.Write(ref counted, true);
                }
            }
            return result;
        }
    }
}
