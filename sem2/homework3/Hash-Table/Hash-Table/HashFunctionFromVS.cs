using static System.Math;

namespace HashTable
{
    /// <summary>
    /// Hash-Function based on C# GetHashCode()
    /// </summary>
    public class HashFunctionFromVS : IHash
    {
        /// <summary>
        /// Takes hash-code of string and divides by table-size
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int CountHash(string data)
        {
            return Abs(data.GetHashCode());
        }
    }
}
