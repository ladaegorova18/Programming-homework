namespace LazyInterface
{
    /// <summary>
    /// Interface for lazy count
    /// </summary>
    public interface ILazy<T>
    {
        /// <summary>
        /// gets result 
        /// </summary>
        T Get();
    }
}
