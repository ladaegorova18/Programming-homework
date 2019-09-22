namespace LazyInterface
{
    /// <summary>
    /// Interface for lazy count
    /// </summary>
    public interface ILazy<out T>
    {
        /// <summary>
        /// gets result 
        /// </summary>
        T Get();
    }
}
