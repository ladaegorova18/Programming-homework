using System;

namespace LazyInterface
{
    /// <summary>
    /// Creates objects of Lazy
    /// </summary>
    public class LazyFactory<T>
    {
        /// <summary>
        /// Creates Lazy object with one-thread work
        /// </summary>
        /// <param name="supplier"> count method </param>
        public static Lazy<T> CreateOneThreading(Func<T> supplier) => new Lazy<T>(supplier);

        /// <summary>
        /// Creates Lazy object with multi-thread work
        /// </summary>
        /// <param name="supplier"> count method </param>
        public static LazyMultiThread<T> CreateMultiThreading(Func<T> supplier) => new LazyMultiThread<T>(supplier);
    }
}
