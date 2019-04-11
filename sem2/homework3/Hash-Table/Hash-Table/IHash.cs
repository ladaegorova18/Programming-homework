namespace HashTable
{
    /// <summary>
    /// Interface for hash functions
    /// </summary>
    public interface IHash
    {
        /// <summary>
        /// Counts hash code of input string
        /// </summary>
        /// <param name="data"> string to count hash code </param>
        /// <returns> hash code of string </returns>
        int CountHash(string data);
    }
}
