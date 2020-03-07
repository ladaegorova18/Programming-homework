using System;

namespace LazyInterface
{
    /// <summary>
    /// lazy one-thread counter
    /// </summary>
    public class Lazy<T> : ILazy<T>
    {
        private Func<T> function;
        private bool counted = false;
        private T result = default;

        /// <summary>
        /// constructor for Lazy object
        /// </summary>
        /// <param name="function"> count method </param>
        public Lazy(Func<T> function)
        {
            this.function = function;
        }

        /// <summary>
        /// calculates result
        /// </summary>
        public T Get()
        {
            if (!counted)
            {
                result = function();
                function = null;
                counted = true;
            }
            return result;
        }
    }
}
