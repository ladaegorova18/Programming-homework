using static System.Math;

namespace HashTable
{
    /// <summary>
    /// Hash function with difficult algorithm
    /// </summary>
    public class HashFunctionCalledPerfect : IHash
    {
        /// <summary>
        /// Takes every 4 symbols from string and makes it an unsigned int
        /// then multiplies it by 73837
        /// after all multiplies logically by 64
        /// </summary>
        /// <param name="data"> input string </param>
        /// <returns> hash code for string</returns>
        public int CountHash(string data)
        {
            int hash = 0;
            for (int i = 0; i < data.Length; i += 4)
            {
                for (int j = i; j < i + 4; ++j)
                {
                    if (j < data.Length)
                    {
                        hash += data[j] << (int)(Pow(2, (j - i)) * 8);
                    }
                }
                hash *= 73837; // 'волшебное' число, как написано на одном сайте
            }
            hash = (hash * 100) & 64;
            return hash >> 32;
        }
    }
}
