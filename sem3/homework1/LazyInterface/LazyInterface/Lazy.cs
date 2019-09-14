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
        private T result = default(T);

        /// <summary>
        /// constructor for Lazy object
        /// </summary>
        /// <param name="function"> count method </param>
        public Lazy(Func<T> function)
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
                try
                {
                    result = function();
                }
                catch (Exception e)
                {
                    result = default(T);
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    counted = true;
                }
            }
            return result;
        }
    }
}
