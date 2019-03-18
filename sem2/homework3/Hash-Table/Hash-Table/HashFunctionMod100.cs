using static System.Math;

namespace Hash_Table
{
    /// <summary>
    /// Hash-Function based on C# GetHashCode()
    /// </summary>
    public class HashFunctionMod100 : IHash
    {
        /// <summary>
        /// Takes hash-code of string and divides by table-size
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int CountHash(string data)
        {
            return Abs(data.GetHashCode() % 100);
        }
    }
}
